using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechlandMysqlMigrateApi.Model;

namespace TechlandMysqlMigrateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly techlandContext _context;

        public PostController(techlandContext context)
        {
            _context = context;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetPosts()
        {
            return Ok(_context.WpPosts.OrderByDescending(d=>d.PostDate).Take(10).ToList());
        }


        [HttpGet("changefiledirectory")]
        public async Task<IActionResult> CopyFilesToAnotherDirectory()
        {
            List<WpPosts> imagelessPosts = new List<WpPosts>();
            var list = Directory.GetFiles(@"C:\Users\Eagha\Desktop\Files", "*", SearchOption.AllDirectories);
            var images = _context.WpPosts.Where(p => p.PostDate>=new DateTime(2020,5,1) && p.PostType == "attachment" && p.Guid != null && !String.IsNullOrWhiteSpace(p.Guid) && (p.PostMimeType== "image/jpeg" || p.PostMimeType== "image/png" || p.PostMimeType=="image/gif")).ToList();
            foreach (var image in images)
            {
                var imgArr = image.Guid.Split('/');
                var imageName =@"\"+ imgArr[imgArr.Length - 1];

                string sourceFile = list.FirstOrDefault(l => l.Contains(imageName));
                string destinationFile = @"C:\Users\Eagha\Desktop\NewFiles\News"+ imageName;

                System.IO.File.Copy(sourceFile, destinationFile,true);

                var newImgArr = imageName.Split('.');
                newImgArr[newImgArr.Length - 2] = newImgArr[newImgArr.Length - 2] + "-341x220";
                var thumbName =  String.Join('.',newImgArr);

                string sourceFileThumb = list.FirstOrDefault(l => l.Contains(thumbName));
                string destinationFileThumb = @"C:\Users\Eagha\Desktop\NewFiles\News\Thumbs"+thumbName;

                if (string.IsNullOrWhiteSpace(sourceFileThumb))
                {
                    imagelessPosts.Add(image);
                    continue;
                }

                System.IO.File.Copy(sourceFileThumb, destinationFileThumb,true);
            }

            return Ok(imagelessPosts);
        }
    }
}