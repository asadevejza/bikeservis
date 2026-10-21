import { Component, OnInit, inject } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Termin, TerminiService } from './termini.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, DatePipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private servis = inject(TerminiService);

  termini: Termin[] = [];
  klijentIme = '';
  usluga = '';
  datum = '';
  greska = '';

  ngOnInit() { this.ucitaj(); }

  ucitaj() {
    this.servis.vratiSve().subscribe(t => (this.termini = t));
  }

  zakazi() {
    this.greska = '';
    this.servis.zakazi(this.klijentIme, this.usluga, this.datum).subscribe({
      next: () => {
        this.klijentIme = this.usluga = this.datum = '';
        this.ucitaj();
      },
      error: e => (this.greska = e.error?.poruka ?? 'Greška pri zakazivanju.')
    });
  }
}
