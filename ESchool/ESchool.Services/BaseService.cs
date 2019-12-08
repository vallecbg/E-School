using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ESchool.Data;
using ESchool.Models;
using ESchool.Services.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ESchool.Services
{
    public abstract class BaseService
    {
        protected BaseService(UserManager<User> userManager,
            ESchoolContext context,
            IMapper mapper)
        {
            this.UserManager = userManager;

            this.Context = context;
            this.Mapper = mapper;
        }

        protected IMapper Mapper { get; }

        protected ESchoolContext Context { get; }

        protected UserManager<User> UserManager { get; }

        protected async Task<string> UploadImage(Cloudinary cloudinary, IFormFile fileform, string name)
        {
            if (fileform == null)
            {
                return null;
            }

            byte[] storyImage;

            using (var memoryStream = new MemoryStream())
            {
                await fileform.CopyToAsync(memoryStream);
                storyImage = memoryStream.ToArray();
            }

            var ms = new MemoryStream(storyImage);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, ms),
                Transformation = new Transformation().Width(200).Height(250).Crop("fit").SetHtmlWidth(250).SetHtmlHeight(100)
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            ms.Dispose();
            return uploadResult.SecureUri.AbsoluteUri;
        }

        protected Cloudinary SetCloudinary()
        {
            Account account = new Account(
                GlobalConstants.CloudinaryCloudName, GlobalConstants.CloudinaryApiKey,
                GlobalConstants.CloudinaryApiSecret);

            Cloudinary cloudinary = new Cloudinary(account);

            return cloudinary;
        }
    }
}
