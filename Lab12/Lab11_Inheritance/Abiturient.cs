using System;
using System.Collections.Generic;
using System.Linq;
using Lab11_Inheritance;

public class Abiturient : Person
{
    // Добавляем коллекцию документов к абитуриенту
    private List<IDocument> documents = new List<IDocument>();

    public string Specialization { get; set; }
    public decimal AverageScore { get; set; }
    public int ExamScore { get; set; }
    public string EducationForm { get; set; }
    public bool HasBenefits { get; set; }

    public override string GetUserType()
    {
        return "Абитуриент";
    }

    // Методы для работы с документами
    public void AddDocument(IDocument document)
    {
        if (document.Validate())
        {
            documents.Add(document);
        }
        else
        {
            throw new ArgumentException("Документ не прошел валидацию");
        }
    }

    public bool RemoveDocument(string documentNumber)
    {
        var document = documents.FirstOrDefault(d =>
            d is Document doc && doc.DocumentNumber == documentNumber);

        if (document != null)
        {
            documents.Remove(document);
            return true;
        }
        return false;
    }

    public List<IDocument> GetAllDocuments()
    {
        return new List<IDocument>(documents);
    }

    public List<IDocument> GetDocumentsByType(string documentType)
    {
        return documents.Where(d => d.DocumentType == documentType).ToList();
    }

    public bool HasValidPassport()
    {
        var passport = documents.OfType<Passport>().FirstOrDefault();
        return passport != null && passport.Validate();
    }

    public bool HasEducationDocument()
    {
        return documents.OfType<EducationDocument>().Any();
    }

    public int GetTotalExamScore()
    {
        return documents.OfType<ExamResult>().Sum(e => e.Score);
    }

    public bool IsApplicationComplete()
    {
        return HasValidPassport() &&
               HasEducationDocument() &&
               documents.OfType<SpecializationApplication>().Any() &&
               documents.OfType<MedicalCertificate>().Any(m => m.IsHealthy);
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nСпециализация: {Specialization}\n" +
               $"Средний балл: {AverageScore}\n" +
               $"Баллы за экзамены: {ExamScore}\n" +
               $"Форма обучения: {EducationForm}\n" +
               $"Льготы: {(HasBenefits ? "Да" : "Нет")}\n" +
               $"Количество документов: {documents.Count}\n" +
               $"Заявление заполнено: {(IsApplicationComplete() ? "Да" : "Нет")}";
    }
}