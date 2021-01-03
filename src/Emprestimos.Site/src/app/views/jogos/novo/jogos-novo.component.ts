import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EnumModel } from '../../../models/enum.model';
import { JogoModel } from '../../../models/jogo.model';
import { AlertService } from '../../../services/alert.service';
import { JogoService } from '../../../services/jogo.service';

@Component({
    selector: 'app-jogos-novo',
    templateUrl: './jogos-novo.component.html',
    styleUrls: ['./jogos-novo.component.css']
})
export class JogosNovoComponent implements OnInit {
    situacoes: EnumModel[];
    generos: EnumModel[];

    form: FormGroup;
    jogo: JogoModel = {
        id: null,
        nome: '',
        genero: '',
        situacao: ''
    };

    constructor(private jogoService: JogoService,
        private router: Router,
        private formBuilder: FormBuilder,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.obterSituacoes();
        this.obterGeneros();
        this.inicializarFormulario();
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            nome: ['', Validators.required],
            genero: ['', Validators.required],
            situacao: ['', Validators.required]
        });
    }

    salvar() {
        this.jogo = this.form.value;

        Object.assign(this.jogo, { genero: parseInt(this.form.value.genero), situacao: parseInt(this.form.value.situacao) });

        this.jogoService.inserir(this.jogo).subscribe(sub => {
            this.router.navigate(['jogos']);
            this.alertService.sucesso(`Amigo ${this.jogo.nome} foi registrado.`)
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
