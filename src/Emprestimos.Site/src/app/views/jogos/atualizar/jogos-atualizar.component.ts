import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EnumModel } from '../../../models/enum.model';
import { JogoModel } from '../../../models/jogo.model';
import { AlertService } from '../../../services/alert.service';
import { JogoService } from '../../../services/jogo.service';

@Component({
    selector: 'app-jogos-atualizar',
    templateUrl: './jogos-atualizar.component.html',
    styleUrls: ['./jogos-atualizar.component.css']
})
export class JogosAtualizarComponent implements OnInit {

    situacoes: EnumModel[];

    generos: EnumModel[];

    id: number;

    form: FormGroup;
    jogo: JogoModel;

    constructor(private jogoService: JogoService,
        private router: Router,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.obterSituacoes();
        this.obterGeneros();
        this.inicializarFormulario();
        this.popularFormulario();
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            nome: ['', Validators.required],
            genero: ['', Validators.required],
            situacao: ['', Validators.required]
        });
    }

    async popularFormulario() {
        setTimeout(() => {
            this.route.params.subscribe(data => {
                this.id = data["id"];
                this.jogoService.obterPorId(data["id"]).subscribe(sub => {
                    this.jogo = JSON.parse(JSON.stringify(sub));
                    this.form.patchValue({
                        nome: this.jogo.nome,
                        situacao: String(this.situacoes.find(x => x.descricao == this.jogo.situacao).codigo),
                        genero: String(this.generos.find(x => x.descricao == this.jogo.genero).codigo)
                    });
                });
            });
        }, 500);
    }

    salvar() {
        this.jogo = this.form.value;

        Object.assign(this.jogo, { genero: parseInt(this.form.value.genero), situacao: parseInt(this.form.value.situacao) });

        this.jogoService.atualizar(this.id, this.jogo).subscribe(sub => {
            this.router.navigate(['jogos']);
            this.alertService.sucesso(`Amigo ${this.jogo.nome} foi atualizado.`)
        })
    }

    private obterSituacoes() {
        this.jogoService.obterSituacoes().subscribe(sub => {
            this.situacoes = sub;
        })
    }

    private obterGeneros() {
        this.jogoService.obterGeneros().subscribe(sub => {
            this.generos = sub;
        })
    }

}
