namespace coIT.AbsencesExport
{
    public class AbwesenheitseintragOhneMapping<TAbsenceType>
    {
        public string Name { get; }
        public int Personalnummer { get; }
        public TAbsenceType AbsenceType { get; }
        public DateTime Start { get; }
        public DateTime Ende { get; }
        public float AbwesenheitsTage { get; }
        public int BruttoTage => (Ende - Start).Days + 1;

        public AbwesenheitseintragOhneMapping(
            string name,
            int personalnummer,
            TAbsenceType absenceType,
            DateTime start,
            DateTime ende,
            float anzahlTage
        )
        {
            Name = name;
            Personalnummer = personalnummer;
            AbsenceType = absenceType;
            Start = start;
            Ende = ende;
            AbwesenheitsTage = anzahlTage;
        }
    }
}
