using System;
namespace CMXAPI.Common
{
	public static class Fun
	{
		public static void StoreFileByPolicyNumber(IFormFileCollection files, string policyNum)
		{
            var path = Path.Combine(Directory.GetCurrentDirectory(), "upload", policyNum);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var file in files)
            {
                if (file.Length > 0 && file != null)
                {
                    var filePath = Path.Combine(path, file.FileName);
                    using (var stream = File.Create(filePath))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
        }

        public static string? GetFileByPolicyNumberAndFileName(string policyNum, string fileName) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "upload", policyNum);
            var file = Directory.GetFiles(path).FirstOrDefault(n => {
                var fname = Path.GetFileNameWithoutExtension(n);
                if (fname == fileName)
                {
                    return true;
                }
                return false;
            });
            return file;
        }
        public static List<string>? GetFilesByPolicyNumber(string policyNum) {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "upload", policyNum);
            var files = Directory.GetFiles(path).Select(n => Path.GetFileName(n)).ToList();
            return files;
        }
	}
}

