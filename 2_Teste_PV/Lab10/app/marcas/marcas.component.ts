import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-marcas',
  templateUrl: './marcas.component.html'
})
export class MarcasComponent {
  public marcas: Marca[];

  constructor(http: HttpClient) {
    http.get<Marca[]>('api/Marcas').subscribe(result => {
      this.marcas = result;
    }, error => console.error(error));
  }
}

interface Marca {
  marcaId: number;
  designacao: string;
}
