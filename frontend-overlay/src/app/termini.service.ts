import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Termin {
  id: number;
  datum: string;
  klijentIme: string;
  usluga: string;
  status: 'Zakazan' | 'Zavrsen';
}

@Injectable({ providedIn: 'root' })
export class TerminiService {
  private http = inject(HttpClient);
  private api = 'http://localhost:5000/api/termini';

  vratiSve(): Observable<Termin[]> {
    return this.http.get<Termin[]>(this.api);
  }

  zakazi(klijentIme: string, usluga: string, datum: string): Observable<Termin> {
    return this.http.post<Termin>(this.api, { klijentIme, usluga, datum });
  }
}
