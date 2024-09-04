namespace coIT.Toolkit.AbsencesExport;

public class Abwesenheitseintrag<TSource, TTarget>
{
  public Abwesenheitseintrag(
    string name,
    int personalnummer,
    TSource sourceAbsenceType,
    TTarget targetAbsenceType,
    DateTime start,
    DateTime ende,
    float anzahlTage
  )
  {
    Name = name;
    Personalnummer = personalnummer;
    AusgangsTyp = sourceAbsenceType;
    ZielTyp = targetAbsenceType;
    Start = start;
    Ende = ende;
    AbwesenheitsTage = anzahlTage;
  }

  public string Name { get; }
  public int Personalnummer { get; }
  public TSource AusgangsTyp { get; }
  public TTarget ZielTyp { get; }
  public DateTime Start { get; }
  public DateTime Ende { get; }
  public float AbwesenheitsTage { get; }
  public int BruttoTage => (Ende - Start).Days + 1;
}
