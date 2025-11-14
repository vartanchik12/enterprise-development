namespace Hospital.Domain.Data;

/// <summary>
/// Seeds initial demo data for the hospital system.
/// </summary>
public class DataSeed
{
    /// <summary>
    /// List of predefined specializations.
    /// </summary>
    public static List<Specialization> Specializations { get; } =
    [
        new Specialization { Id = 1, Name = "Кардиолог" },
        new Specialization { Id = 2, Name = "Невролог" },
        new Specialization { Id = 3, Name = "Педиатр" },
        new Specialization { Id = 4, Name = "Онколог" },
        new Specialization { Id = 5, Name = "Дерматолог" },
        new Specialization { Id = 6, Name = "Психиатр" },
        new Specialization { Id = 7, Name = "Хирург" },
        new Specialization { Id = 8, Name = "Ортопед" },
        new Specialization { Id = 9, Name = "Офтальмолог" },
        new Specialization { Id = 10, Name = "Гинеколог" }
    ];

    /// <summary>
    /// List of predefined doctors.
    /// </summary>
    public List<Doctor> Doctors { get; } =
    [
        new Doctor { Id = 1, Passport = "4501 123456", FullName = "Иванов Сергей Петрович", BirthDate = new DateOnly(1975, 3, 15), Specialization = Specializations[0], WorkExperience = 15 },
        new Doctor { Id = 2, Passport = "4502 234567", FullName = "Петрова Анна Владимировна", BirthDate = new DateOnly(1980, 7, 22), Specialization = Specializations[1], WorkExperience = 12 },
        new Doctor { Id = 3, Passport = "4503 345678", FullName = "Сидоров Алексей Иванович", BirthDate = new DateOnly(1982, 11, 8), Specialization = Specializations[2], WorkExperience = 10 },
        new Doctor { Id = 4, Passport = "4504 456789", FullName = "Кузнецова Мария Сергеевна", BirthDate = new DateOnly(1978, 5, 30), Specialization = Specializations[3], WorkExperience = 14 },
        new Doctor { Id = 5, Passport = "4505 567890", FullName = "Васильев Дмитрий Николаевич", BirthDate = new DateOnly(1985, 9, 12), Specialization = Specializations[4], WorkExperience = 8 },
        new Doctor { Id = 6, Passport = "4506 678901", FullName = "Николаева Ольга Борисовна", BirthDate = new DateOnly(1970, 12, 3), Specialization = Specializations[5], WorkExperience = 20 },
        new Doctor { Id = 7, Passport = "4507 789012", FullName = "Федоров Игорь Васильевич", BirthDate = new DateOnly(1983, 2, 28), Specialization = Specializations[6], WorkExperience = 9 },
        new Doctor { Id = 8, Passport = "4508 890123", FullName = "Алексеева Татьяна Дмитриевна", BirthDate = new DateOnly(1979, 6, 17), Specialization = Specializations[7], WorkExperience = 13 },
        new Doctor { Id = 9, Passport = "4509 901234", FullName = "Павлов Андрей Викторович", BirthDate = new DateOnly(1981, 4, 5), Specialization = Specializations[8], WorkExperience = 11 },
        new Doctor { Id = 10, Passport = "4510 012345", FullName = "Семенова Елена Александровна", BirthDate = new DateOnly(1976, 8, 25), Specialization = Specializations[9], WorkExperience = 16 }
    ];

    /// <summary>
    /// List of predefined patients.
    /// </summary>
    public List<Patient> Patients { get; } =
    [
        new Patient { Id = 1, Passport = "4501 555001", FullName = "Смирнов Александр Игоревич", Sex = Sex.Male, BirthDate = new DateOnly(1990, 5, 15), Address = "ул. Ленина, д. 10, кв. 25", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-11-11" },
        new Patient { Id = 2, Passport = "4502 555002", FullName = "Ковалева Ирина Сергеевна", Sex = Sex.Female, BirthDate = new DateOnly(1985, 8, 22), Address = "ул. Мира, д. 5, кв. 14", BloodType = BloodType.I, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-22-22" },
        new Patient { Id = 3, Passport = "4503 555003", FullName = "Морозов Петр Васильевич", Sex = Sex.Male, BirthDate = new DateOnly(2004, 3, 10), Address = "пр. Победы, д. 25, кв. 7", BloodType = BloodType.III, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-33-33" },
        new Patient { Id = 4, Passport = "4504 555004", FullName = "Волкова Наталья Дмитриевна", Sex = Sex.Female, BirthDate = new DateOnly(1995, 11, 30), Address = "ул. Садовая, д. 15, кв. 32", BloodType = BloodType.IV, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-44-44" },
        new Patient { Id = 5, Passport = "4505 555005", FullName = "Белов Андрей Павлович", Sex = Sex.Male, BirthDate = new DateOnly(1982, 7, 5), Address = "ул. Центральная, д. 8, кв. 19", BloodType = BloodType.II, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-55-55" },
        new Patient { Id = 6, Passport = "4506 555006", FullName = "Жукова Светлана Олеговна", Sex = Sex.Female, BirthDate = new DateOnly(1973, 12, 18), Address = "ул. Лесная, д. 3, кв. 41", BloodType = BloodType.I, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-66-66" },
        new Patient { Id = 7, Passport = "4507 555007", FullName = "Тихонов Михаил Юрьевич", Sex = Sex.Male, BirthDate = new DateOnly(1992, 2, 28), Address = "пр. Строителей, д. 12, кв. 8", BloodType = BloodType.III, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-77-77" },
        new Patient { Id = 8, Passport = "4508 555008", FullName = "Орлова Дарья Викторовна", Sex = Sex.Female, BirthDate = new DateOnly(1988, 9, 9), Address = "ул. Молодежная, д. 7, кв. 23", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-88-88" },
        new Patient { Id = 9, Passport = "4509 555009", FullName = "Григорьев Виктор Иванович", Sex = Sex.Male, BirthDate = new DateOnly(1975, 6, 14), Address = "ул. Речная, д. 18, кв. 15", BloodType = BloodType.IV, RHFactor = RHFactor.Negative, PhoneNumber = "+7 (915) 100-99-99" },
        new Patient { Id = 10, Passport = "4510 555010", FullName = "Соколова Марина Анатольевна", Sex = Sex.Female, BirthDate = new DateOnly(1998, 4, 3), Address = "ул. Школьная, д. 9, кв. 11", BloodType = BloodType.I, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 100-00-00" },
        new Patient { Id = 11, Passport = "4511 555011", FullName = "Новиков Сергей Петрович", Sex = Sex.Male, BirthDate = new DateOnly(1980, 1, 15), Address = "ул. Солнечная, д. 11, кв. 5", BloodType = BloodType.II, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 111-11-11" },
        new Patient { Id = 12, Passport = "4512 555012", FullName = "Павлова Елена Владимировна", Sex = Sex.Female, BirthDate = new DateOnly(1983, 12, 10), Address = "ул. Весенняя, д. 20, кв. 33", BloodType = BloodType.III, RHFactor = RHFactor.Positive, PhoneNumber = "+7 (915) 122-22-22" }
    ];

    /// <summary>
    /// List of predefined appointments.
    /// </summary>
    public List<Appointment> Appointments { get; } =
    [
        new Appointment { Id = 1, AppointmentTime = new DateTime(2025, 8, 15), RoomNumber = 101, IsFollow = false, PatientId = 1, DoctorId = 1 },
        new Appointment { Id = 2, AppointmentTime = new DateTime(2025, 9, 10), RoomNumber = 205, IsFollow = true, PatientId = 2, DoctorId = 3 },
        new Appointment { Id = 3, AppointmentTime = new DateTime(2025, 10, 16), RoomNumber = 302, IsFollow = false, PatientId = 3, DoctorId = 5 },
        new Appointment { Id = 4, AppointmentTime = new DateTime(2025, 10, 16), RoomNumber = 104, IsFollow = true, PatientId = 4, DoctorId = 7 },
        new Appointment { Id = 5, AppointmentTime = new DateTime(2025, 10, 17), RoomNumber = 208, IsFollow = false, PatientId = 5, DoctorId = 2 },
        new Appointment { Id = 6, AppointmentTime = new DateTime(2025, 10, 17), RoomNumber = 305, IsFollow = true, PatientId = 6, DoctorId = 9 },
        new Appointment { Id = 7, AppointmentTime = new DateTime(2025, 10, 18), RoomNumber = 112, IsFollow = false, PatientId = 7, DoctorId = 4 },
        new Appointment { Id = 8, AppointmentTime = new DateTime(2025, 10, 18), RoomNumber = 214, IsFollow = true, PatientId = 8, DoctorId = 6 },
        new Appointment { Id = 9, AppointmentTime = new DateTime(2025, 9, 19), RoomNumber = 309, IsFollow = false, PatientId = 9, DoctorId = 8 },
        new Appointment { Id = 10, AppointmentTime = new DateTime(2025, 10, 19), RoomNumber = 117, IsFollow = true, PatientId = 10, DoctorId = 10 },
        new Appointment { Id = 11, AppointmentTime = new DateTime(2025, 10, 15), RoomNumber = 104, IsFollow = false, PatientId = 3, DoctorId = 1 },
        new Appointment { Id = 12, AppointmentTime = new DateTime(2025, 10, 20), RoomNumber = 201, IsFollow = false, PatientId = 11, DoctorId = 2 },
        new Appointment { Id = 13, AppointmentTime = new DateTime(2025, 10, 21), RoomNumber = 202, IsFollow = true, PatientId = 11, DoctorId = 4 },
        new Appointment { Id = 14, AppointmentTime = new DateTime(2025, 10, 22), RoomNumber = 203, IsFollow = false, PatientId = 11, DoctorId = 6 },
        new Appointment { Id = 15, AppointmentTime = new DateTime(2025, 10, 23), RoomNumber = 204, IsFollow = false, PatientId = 12, DoctorId = 3 },
        new Appointment { Id = 16, AppointmentTime = new DateTime(2025, 10, 24), RoomNumber = 205, IsFollow = true, PatientId = 12, DoctorId = 7 },
        new Appointment { Id = 17, AppointmentTime = new DateTime(2025, 10, 15), RoomNumber = 101, IsFollow = false, PatientId = 1, DoctorId = 1 },
        new Appointment { Id = 18, AppointmentTime = new DateTime(2025, 10, 20), RoomNumber = 101, IsFollow = true, PatientId = 2, DoctorId = 3 }
    ];
}