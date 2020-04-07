import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public filmes: Filme[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Filme[]>(`${baseUrl}api/filme`).subscribe(result => {
      this.filmes = result;
    }, error => console.error(error));
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
}

