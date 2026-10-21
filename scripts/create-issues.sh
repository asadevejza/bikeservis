#!/usr/bin/env bash
# Kreira issue-e #1-#9 u repozitoriju (potreban GitHub CLI: gh auth login).
# #1-#6 se odmah zatvaraju (već urađeni), #7-#9 ostaju otvoreni.
set -e
gh label create feature --color 0E8A16 2>/dev/null || true

done_titles=("Projekat i struktura repozitorija" "Model Termin i baza" "Zakazivanje termina (API)" "Lista termina (API)" "Angular: ekran Moji termini" "Angular: forma za zakazivanje")
for t in "${done_titles[@]}"; do
  url=$(gh issue create --title "$t" --body "Urađeno u početnom stanju projekta." --label feature)
  gh issue close "${url##*/}"
done

gh issue create --title "Otkazivanje termina" --label feature --body "Kao klijent želim otkazati zakazani termin kako bi mehaničar mogao dati slot drugom klijentu.

Kriteriji prihvatanja:
- [ ] Klijent može otkazati termin iz liste \"Moji termini\"
- [ ] Otkazivanje nije moguće manje od 24h prije termina
- [ ] Obavezan je razlog otkazivanja
- [ ] Status termina postaje \"Otkazan\"
- [ ] Već otkazan termin se ne može ponovo otkazati"

gh issue create --title "Lista termina po mehaničaru" --label feature --body "Kao mehaničar želim vidjeti svoje termine kako bih planirao dan."
gh issue create --title "Cjenovnik usluga" --label feature --body "Kao klijent želim vidjeti cjenovnik usluga prije zakazivanja."
