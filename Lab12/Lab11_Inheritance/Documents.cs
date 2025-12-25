using System;
using System.Collections.Generic;

namespace Lab11_Inheritance
{
    // Интерфейс для всех документов
    public interface IDocument
    {
        string GetInfo();
        bool Validate();
        string DocumentType { get; }
    }

    // Базовый абстрактный класс документа
    public abstract class Document : IDocument
    {
        public string DocumentNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string IssuingAuthority { get; set; }

        public abstract string DocumentType { get; }

        public Document()
        {
            IssueDate = DateTime.Now;
        }

        public virtual string GetInfo()
        {
            return $"Тип: {DocumentType}\nНомер: {DocumentNumber}\nДата выдачи: {IssueDate.ToShortDateString()}\nВыдан: {IssuingAuthority}";
        }

        public virtual bool Validate()
        {
            return !string.IsNullOrEmpty(DocumentNumber) &&
                   !string.IsNullOrEmpty(IssuingAuthority) &&
                   IssueDate <= DateTime.Now;
        }
    }

    // Паспортные данные
    public class Passport : Document
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }

        public override string DocumentType => "Паспорт";

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nФИО: {FullName}\nДата рождения: {BirthDate.ToShortDateString()}\nМесто рождения: {BirthPlace}\nПол: {Gender}\nГражданство: {Citizenship}";
        }

        public override bool Validate()
        {
            return base.Validate() &&
                   !string.IsNullOrEmpty(FullName) &&
                   !string.IsNullOrEmpty(BirthPlace) &&
                   !string.IsNullOrEmpty(Citizenship) &&
                   BirthDate < DateTime.Now;
        }
    }

    // Документ об образовании
    public class EducationDocument : Document
    {
        public string InstitutionName { get; set; }
        public int GraduationYear { get; set; }
        public string Qualification { get; set; }
        public decimal AverageGrade { get; set; }

        public override string DocumentType => "Документ об образовании";

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nУчебное заведение: {InstitutionName}\nГод окончания: {GraduationYear}\nКвалификация: {Qualification}\nСредний балл: {AverageGrade}";
        }

        public override bool Validate()
        {
            return base.Validate() &&
                   !string.IsNullOrEmpty(InstitutionName) &&
                   !string.IsNullOrEmpty(Qualification) &&
                   GraduationYear > 1900 && GraduationYear <= DateTime.Now.Year &&
                   AverageGrade >= 0 && AverageGrade <= 10;
        }
    }

    // Результаты экзамена
    public class ExamResult : Document
    {
        public string Subject { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
        public int MaxScore { get; set; } = 100;

        public override string DocumentType => "Результат экзамена";

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nПредмет: {Subject}\nБаллы: {Score}/{MaxScore}\nДата экзамена: {ExamDate.ToShortDateString()}";
        }

        public override bool Validate()
        {
            return base.Validate() &&
                   !string.IsNullOrEmpty(Subject) &&
                   Score >= 0 && Score <= MaxScore &&
                   ExamDate <= DateTime.Now;
        }

        public bool IsPassed()
        {
            return Score >= 60; // Проходной балл
        }
    }

    // Заявление на специальность
    public class SpecializationApplication : Document
    {
        public string SpecializationCode { get; set; }
        public string SpecializationName { get; set; }
        public int Priority { get; set; } // Приоритет выбора (1, 2, 3)
        public string StudyForm { get; set; } // Очная, заочная
        public bool IsBudget { get; set; }

        public override string DocumentType => "Заявление на специальность";

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nКод специальности: {SpecializationCode}\nНазвание: {SpecializationName}\nПриоритет: {Priority}\nФорма обучения: {StudyForm}\nБюджет: {(IsBudget ? "Да" : "Нет")}";
        }

        public override bool Validate()
        {
            return base.Validate() &&
                   !string.IsNullOrEmpty(SpecializationCode) &&
                   !string.IsNullOrEmpty(SpecializationName) &&
                   Priority >= 1 && Priority <= 3 &&
                   !string.IsNullOrEmpty(StudyForm);
        }
    }

    // Медицинская справка
    public class MedicalCertificate : Document
    {
        public bool IsHealthy { get; set; }
        public string Restrictions { get; set; }
        public DateTime ValidUntil { get; set; }
        public string ClinicName { get; set; }

        public override string DocumentType => "Медицинская справка";

        public override string GetInfo()
        {
            return base.GetInfo() +
                   $"\nГоден к обучению: {(IsHealthy ? "Да" : "Нет")}\nОграничения: {Restrictions}\nДействительна до: {ValidUntil.ToShortDateString()}\nПоликлиника: {ClinicName}";
        }

        public override bool Validate()
        {
            return base.Validate() &&
                   !string.IsNullOrEmpty(ClinicName) &&
                   ValidUntil > DateTime.Now;
        }
    }
}