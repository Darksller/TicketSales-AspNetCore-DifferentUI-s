using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSalesSystem.BLL.DTOs.UserDTOs;
using TicketSalesSystem.BLL.Interfaces;

namespace TicketSalesSystem.ReactUI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private IUserService _userService;
		private ITokenService _tokenService;
		public UserController(ITokenService tokenService, IUserService userService, IConfiguration configuration)
		{
			_userService = userService;
			_tokenService = tokenService;
			_configuration = configuration;
		}

		[HttpPost("registration")]
		public async Task<ActionResult<ResponseUserDTO>> Register(RequestUserDTO request)
		{
			var userResponse = await _userService.Register(request);
			if (userResponse is null)
			{
				throw new Exception();
			}
			return Ok(userResponse);
		}

		[HttpPost]
		[Route("login")]
		public async Task<ActionResult<ResponseUserDTO>> Login(RequestUserDTO request)
		{
			var userResponse = await _userService.Login(request);
			if (userResponse is null)
			{
				throw new Exception();
			}
			SetRefreshToken(new RefreshTokenDTO
			{
				RefreshToken = userResponse.RefreshToken,
				Created = userResponse.Created,
				Expires = userResponse.Expires
			});

			return Ok(userResponse);
		}

		[HttpPost]
		[Route("logout")]
		public async Task<ActionResult<string>> Logout()
		{
			var refreshToken = Request.Cookies["refreshToken"];

			var user = await _userService.Logout(refreshToken!);

			Response.Cookies.Delete("refreshToken");

			return Ok(refreshToken);
		}

		[HttpPost]
		[Route("refresh")]
		public async Task<ActionResult<string>> RefreshToken()
		{
			var refreshToken = Request.Cookies["refreshToken"];

			var validate = await _tokenService.ValidateRefreshToken(refreshToken);

			if (!validate)
				Unauthorized();

			var user = await _userService.Refresh(refreshToken);

			SetRefreshToken(new RefreshTokenDTO()
			{
				RefreshToken = user.RefreshToken,
				Created = user.Created,
				Expires = user.Expires
			});

			return Ok(user);
		}
		private void SetRefreshToken(RefreshTokenDTO refreshToken)
		{
			var cookieOptions = new CookieOptions()
			{
				HttpOnly = true,
				Expires = refreshToken.Expires,
				SameSite = SameSiteMode.Lax
			};

			Response.Cookies.Append("refreshToken", refreshToken.RefreshToken, cookieOptions);
		}
	}
}
