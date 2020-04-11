import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent {
  public filmesCampeoes: Filme[];

  constructor(private router: Router) {
    this.filmesCampeoes = this.router.getCurrentNavigation().extras.state as Filme[];

    if (!this.filmesCampeoes)
      this.router.navigate(['']);
  }
}

interface Filme {
  titulo: string;
}
