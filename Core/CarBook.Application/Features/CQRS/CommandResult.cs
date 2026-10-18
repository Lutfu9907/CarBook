namespace CarBook.Application.Features.CQRS
{
    // İlişkili kayıt doğrulaması yapan komutların sonucu
    public enum CommandResult
    {
        Success,
        NotFound,   // Güncellenecek/silinecek kayıt yok
        Invalid     // İlişkili kayıt (marka, araç, fiyat türü vb.) yok
    }
}
