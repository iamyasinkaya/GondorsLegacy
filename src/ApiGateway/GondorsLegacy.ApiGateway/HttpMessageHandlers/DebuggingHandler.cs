namespace GondorsLegacy.ApiGateway.HttpMessageHandlers
{
    // DebuggingHandler sınıfı, HTTP istekleri ve yanıtları üzerinde geliştirme amaçlı izleme sağlamak için kullanılır.
    public class DebuggingHandler : DelegatingHandler
    {
        // DebuggingHandler sınıfının parametresiz yapıcı metodu.
        public DebuggingHandler()
        {
            // Yapıcı metod, sınıf örneği oluşturulurken çalışacak kodları içerebilir.
        }

        // SendAsync metodu, HTTP isteğini işlemek ve HTTP yanıtını dönmek için asenkron bir görev geri döndürür.
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Base sınıfın SendAsync metodu çağrılarak HTTP isteği işlenir.
            var response = await base.SendAsync(request, cancellationToken);

            // İşlenmiş yanıt döndürülür.
            return response;
        }
    }
}
