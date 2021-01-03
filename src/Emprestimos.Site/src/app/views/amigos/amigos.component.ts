import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AmigoModel } from '../../models/amigo.model';
import { AlertService } from '../../services/alert.service';
import { AmigoService } from '../../services/amigo.service';

@Component({
    selector: 'app-amigos',
    templateUrl: './amigos.component.html',
    styleUrls: ['./amigos.component.css']
})
export class AmigosComponent implements OnInit {
    amigos: AmigoModel[];

    constructor(private amigosService: AmigoService,
        private router: Router,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.obterAmigos();
    }

    obterAmigos() {
        this.amigosService.obter().subscribe(sub => {
            this.amigos = sub;
        })
    }

    novo() {
        this.router.navigate(['novo-amigo']);
    }

    editar(amigo: AmigoModel) {
        this.router.navigate([`amigo/${amigo.id}`]);
    }

    excluir(amigo: AmigoModel) {
        this.amigosService.remover(amigo.id).subscribe(sub => {
            this.alertService.sucesso(`Amigo "${amigo.apelido}" foi exluido e todos seus emprestimos foram finalizados`);
            this.obterAmigos();
        });
    }

    devolverTodos(amigo: AmigoModel) {
        this.amigosService.devolverTodosJogos(amigo.id).subscribe(sub => {
            this.alertService.sucesso(`Todos os jogos do "${amigo.apelido} foram devolvidos"`);
            this.obterAmigos();
        });
    }
}
