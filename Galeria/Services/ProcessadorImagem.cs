namespace Galeria.Services
{
    public class ProcessadorImagem : IProcessadorImagem
    {
        public async Task<bool> AplicarEfeitoAsync(string caminhoArquivo, EfeitoImagem efeito)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExcluirImagemAsync(string caminhoArquivoImagem)
        {
            if (File.Exists(caminhoArquivoImagem))
            {
                try
                {
                    File.Delete(caminhoArquivoImagem);
                    return true;
                }
                catch (IOException)
                {
                return await Task.FromResult(false);
                }
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> SalvarUploadImagemAsync(string caminhoArquivoImagem, IFormFile imagem)
        {
            if(imagem is null)
            {
                return false;
            }
            var ms = new MemoryStream();
            await imagem.CopyToAsync(ms);
            ms.Position = 0;
            return await SalvarImagemComoWebpAsync(caminhoArquivoImagem, ms, true);
        }

        private static async Task<bool> SalvarImagemComoWebpAsync(string
            caminhoArquivoImagem, MemoryStream ms, bool quadrada = true)
        {
            var img = await Image.LoadAsync(ms);
            var extensaoImagem = caminhoArquivoImagem.Substring(caminhoArquivoImagem.LastIndexOf('.')).ToLower();
            if (quadrada)
            {
                var tamanho = img; //.Size();
                var ladoMenor = (tamanho.Height < tamanho.Width) ? tamanho.Height : tamanho.Width;
                img.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(ladoMenor, ladoMenor),
                    Mode = ResizeMode.Crop
                }).BackgroundColor(new Rgba32(255, 255, 255, 0)));
            }
            caminhoArquivoImagem = caminhoArquivoImagem.Replace(extensaoImagem, ".webp");
            await img.SaveAsWebpAsync(caminhoArquivoImagem);
            return true;
        }
    }
}
