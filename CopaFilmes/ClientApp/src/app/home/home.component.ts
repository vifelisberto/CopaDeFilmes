import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  private baseUrl: string;
  public filmes: Filme[];
  public countChecks: number = 0;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;

    this.http.get<Filme[]>(`${baseUrl}api/filme`).subscribe(result => {
      this.filmes = result;
    }, error => console.error(error));
  }

  generate() {
    if (this.countChecks != 8) {
      console.error("Quantidade de filmes incorreta.");
    }

    let filmesChecked = this.filmes.filter(x => x.checked);
    this.http.post(`${this.baseUrl}api/campeonato`, filmesChecked)
      .subscribe(result =>
      {
        debugger;
        console.log(result);
        this.router.navigate(['resultado'], { state: result });
      }, error => console.error(error));
  }

  posChange(filme, event) {
    if (this.countChecks >= 8) {
      event.target.checked = false;
      filme.checked = false;
    }

    this.countChecks = this.filmes ? this.filmes.filter(x => x.checked).length : 0;
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
  checked: boolean;
}

