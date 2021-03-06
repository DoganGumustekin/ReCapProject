using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath) //filePath CarImageManger den gelen dosyamın kaydedildiği adres ve adı
        {
            if (File.Exists(filePath)) //parametre de gelen adreste öyle bir dosya varmı diye kontrol ediliyor.
            {
                File.Delete(filePath); //varsa sil
            }
        }

        public string Update(IFormFile file, string filePath, string root) //güncellenecek yeni dosya, eskidosyamın kayıt dizini, yeni kayıt dizini
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath); //eski dosya silindi
            }
            return Upload(file, root); //yerine yenisi geçecek
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0) //dosya uzunluğu byte olarak alınır eğer 0 dan üyükse dosya gönerilmiş değilse gönderilmemiş
            {
                if (!Directory.Exists(root)) //CarImageManager den sana bir adres gönderdim
                {
                    Directory.CreateDirectory(root);                                   
                }
                string extension = Path.GetExtension(file.FileName); //Yükleyeceğimiz dosyanın uzantısını alır. Örn: .jpg
                string guid = Guid.NewGuid().ToString(); //Dosyanın yeni random ismi(GUID) elde edilir.
                string filePath = guid + extension; //ismi(GUID) ile dosya uzantısını birleştirerek yeni dosya yolu oluşturur.

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen 
                                            //IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();     //arabellekten siler.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }
            }
            return null;
        }
    }
}
