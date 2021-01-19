import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { AlertService } from 'src/app/services/alert.service';
import { Sonda } from './models/sonda';
import { HomeService } from './services/home.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],

})
export class HomeComponent implements OnInit {
  title = 'home';
  condition = false;
  coordenadasGrid = false;
  coordenadaSonda1;
  coordenadaSonda2;

  constructor(private homeService: HomeService, private formBuilder: FormBuilder, private alertService: AlertService) { }

  sonda: Sonda[] = [new Sonda("", ""), new Sonda("", "")];
  comandos = "https://i.pinimg.com/564x/1c/c0/60/1cc06053c2aa939bd04efd766cc2e817.jpg";



  ngOnInit() {

  }



  monvimentar() {

    let validacao = true;


    if (this.sonda[0].coordenadas == ""
      || this.sonda[0].movimentos == ""
      || this.sonda[1].coordenadas == ""
      || this.sonda[1].movimentos == "") {
      validacao = false;
      this.alertService.error("", "Todos campos são obrigatórios!", "OK");
    }

    if (this.sonda[0].coordenadas.length < 5
      || this.sonda[1].coordenadas.length < 5
    ) {
      validacao = false;
      this.alertService.error("", "Por favor, preencha os campos no formato correto!", "OK");
    }


    if (!new RegExp("^(?!\s*$)(?:n|e|s|w|l|r|m|)+$").test(this.sonda[0].movimentos.toLocaleLowerCase())
      || !new RegExp("^(?!\s*$)(?:n|e|s|w|l|r|m|)+$").test(this.sonda[1].movimentos.toLocaleLowerCase())
    ) {
      validacao = false;
      this.alertService.error("", "Os pontos para movimentação só podem ser N, E, S ou W para os cardinais e para direção L, R e M", "OK");
    }


    if (validacao) {
      this.comandos = "./assets/sonda.gif";
      this.condition = true;
      setTimeout(() => {
        this.homeService.monvimentar(this.sonda).subscribe(data => {
          this.condition = false;
          this.comandos = "./assets/visao_marte.jpeg";
          this.coordenadasGrid = true;
          this.coordenadaSonda1 = data[0];
          this.coordenadaSonda2 = data[1];
          this.coordenadasGrafico(`sonda1`, data[0]);
          this.coordenadasGrafico(`sonda2`, data[1]);
        });
      },
        3000);
    }



  }

  coordenadasGrafico(sondaId: string, coordenadas: string) {
    let coordenada = coordenadas.split("");
    const sonda1 = <HTMLCanvasElement>document.getElementById(sondaId);
    var ctx = sonda1.getContext("2d");

    ctx.moveTo(parseInt(coordenada[0]), parseInt(coordenada[2]));
    ctx.lineTo(200, 100);
    ctx.stroke();
  }

}
