using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;

namespace FixesAPI.Validators
{
    public class ValidateImage
    {
        public const int ImageMinimumBytes = 512;

        public bool IsValid(IFormFile Image)
        {
            //-------------------------------------------
            //  Try to instantiate new Bitmap, if .NET will throw exception
            //  we can assume that it's not a valid image
            //-------------------------------------------
            try
            {
                using (var bitmap = new Bitmap(Image.OpenReadStream()))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Image.OpenReadStream().Position = 0;
            }

            return true;
        }

    }
}
