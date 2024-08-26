# coIT.AbsencesExport
.Net Winforms Tool um Zeiterfassungen (Abwesenheiten) von TimeCard nach GDI oder Clockodo nach GDI zu exportieren

TODO: JSON mit Clodotypen entfernen und dafür direkt abrufen

Hierzu kann man beziehungen Festlegen und für einen gewissen Zeitraum die Daten exportieren.

![Bild der AbsencesExport Anwendung](assets/images/AbsencesExportClockodoToGDI.PNG)

![Bild der AbsencesExport Anwendung](assets/images/AbsencesExportTimeCardToGDI.PNG)

### Programmaufbau

Ordner:
- config
Hier liegen Json Konfigurations Dateien um mit den APIs von Clockodo, Timecard und GDI zu kommunizieren

- Configuration
Hier werden die Konfiguration ins Programm geladen 

- Mapping
Hier werden die Daten zusammengeführt

- Specifications


- UserForms
Hier liegen die einzelnen WindowsFormsFenster 



### Konfiguration

Für die Abfrage über die API muss man Für Clockodo und Timecard einen API Schlüssel und API Benutzter mitgeben. 

die Konfigurationen liegen auf unterschiedlichen pfaden

Clockodo Konfiguration: config/clockodo-settings.json
Timecard Konfigurationen: config/timecard-settings.json
GDI Konfiguration: config/gdi-settings.json

Clockodo-GDI-Mapping (Verknüpfungen): config/clockodo-mapping-settings.json
Timecard-GDI-Mapping (Verknüpfungen): config/timecard-mapping-settings.json

### Filter

TimeCard:
- Artzbesuch
- Todefall 1.Grad
- Dienstgang
- JAZ
- Istzeit
- Krank
- Pause
- Schule 
- Sollzeit
- Urlaub
- Zeitausgleich (nicht nutzen)
- Feiertag
- Eigene Hochzeit
- Kind Krank
- Home Office
- Urlaub Umzug
- Im Haus
- Dienstreise
- Kundenbesuch
- Krank ohne Krankenschein
- Krank mit Krankenschein
- Abwesenheit Teilzeitkraft

Clockodo:
- Normaler Urlaubtag
- Sonderurlaub
- Überstundenabbau
- Krankheit
- Krankheit eines Kindes
- Schule / Weiterbildung
- Mutterschutz
- Home Office
-Arbeit außer Haus
- Sonderurlaub
- Krankheit (unbezahlt)
- Krankheit eines Kindes (unbezahlt)
- Quarantäne
- Militär-/ersatzdienst
- eAU Übergangstyp

GDI:
- Kind Krankheit
- Erholungsurlaub
- Sonderurlaub
- Lohnfortzahlung mit AU
- Bescheinigung (mit AAG) krank
- Lohnfortzahlung ohne AU
- Bescheinigung (mit AAG) krank


### Extern benutzte Projekte/Libraries

Benutzt folgende Libraries: 
* coIT.Libraries.Clockodo-Old
* coIT.Libraries.Gdi
* coIT.Libraries.TimeCard