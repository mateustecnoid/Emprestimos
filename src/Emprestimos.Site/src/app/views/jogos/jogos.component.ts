import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JogoModel } from '../../models/jogo.model';
import { AlertService } from '../../services/alert.service';
import { JogoService } from '../../services/jogo.service';

@Component({
    selector: 'app-jogos',
    templateUrl: './jogos.component.html',
    styleUrls: ['./jogos.component.css']
})
export class JogosComponent implements OnInit {
    jogos: JogoModel[];

    constructor(private jogoService: JogoService,
        private router: Router,
        private alertService: AlertService) { }

    ngOnInit(): void {        
        this.obterJogos();
    }

    obterJogos() {
        this.jogoService.obter().subscribe(sub => {
            this.jogos = sub;
        })
    }

    novo() {
        this.router.navigate(['novo-jogo']);
    }

    editar(jogo: JogoModel) {
        this.router.navigate([`jogo/${jogo.id}`]);
    }

    excluir(jogo: JogoModel) {
        this.jogoService.remover(jogo.id).subscribe(sub => {
            this.alertService.sucesso(`Jogo "${jogo.nome}" foi exluido`);
            this.obterJogos();
        });
    }

}
