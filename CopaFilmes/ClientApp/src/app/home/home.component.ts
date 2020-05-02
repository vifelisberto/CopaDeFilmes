import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  private baseUrl: string;
  private numberMovie = 8;
  public filmes: Filme[];
  public countChecks: number = 0;

  private subscribes: Subscription[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {
    this.baseUrl = baseUrl;

    this.subscribes.push(this.http.get<Filme[]>(`${baseUrl}api/filme`).subscribe(result => {
      this.filmes = result;
    }, error => console.error(error)));
  }

  generate() {
    if (this.countChecks != this.numberMovie) {
      console.error("Quantidade de filmes incorreta.");
    }

    let filmesChecked = this.filmes.filter(x => x.checked);
    this.subscribes.push(this.http.post(`${this.baseUrl}api/campeonato`, filmesChecked)
      .subscribe(result => {
        this.router.navigate(['resultado'], { state: result });
      }, error => console.error(error)));
  }

  posChange(filme, event) {
    if (this.countChecks >= this.numberMovie) {
      event.target.checked = false;
      filme.checked = false;
    }

    this.countChecks = this.filmes ? this.filmes.filter(x => x.checked).length : 0;
  }

  ngOnDestroy() {
    this.subscribes.forEach((x) => x.unsubscribe());
  }
}

interface Filme {
  id: string;
  titulo: string;
  ano: number;
  nota: number;
  checked: boolean;
}

