import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AmigoModel } from '../../../models/amigo.model';
import { EmprestimoModel } from '../../../models/emprestimo.model';
import { JogoModel } from '../../../models/jogo.model';
import { AlertService } from '../../../services/alert.service';
import { AmigoService } from '../../../services/amigo.service';
import { EmprestimoService } from '../../../services/emprestimo.service';
import { JogoService } from '../../../services/jogo.service';

@Component({
    selector: 'app-emprestimos-novo',
    templateUrl: './emprestimos-novo.component.html',
    styleUrls: ['./emprestimos-novo.component.css']
})
export class EmprestimosNovoComponent implements OnInit {
    amigos: AmigoModel[];
    jogos: JogoModel[];

    form: FormGroup;
    emprestimo: EmprestimoModel = {
        id: null,
        amigoId: null,
        jogoId: null,
        dataDevolucao: null,
        dataEmprestimo: null
    }

    constructor(private emprestimoService: EmprestimoService,
        private jogoService: JogoService,
        private amigoService: AmigoService,
        private router: Router,
        private formBuilder: FormBuilder,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.obterAmigos();
        this.obterJogos();
        this.inicializarFormulario();
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            amigoId: ['', Validators.required],
            jogoId: ['', Validators.required]
        });
    }

    salvar() {
        if (this.form.valid) {
            this.emprestimo = this.form.value;

            Object.assign(this.emprestimo, { amigoId: parseInt(this.form.value.amigoId), jogoId: parseInt(this.form.value.jogoId) });

            this.emprestimoService.inserir(this.emprestimo).subscribe(sub => {
                this.router.navigate(['emprestimos']);
                this.alertService.sucesso(`Emprestimo ${this.emprestimo.id} foi registrado.`)
            })
        }
        else
            this.alertService.aviso("O formulário não foi preenchido de forma correta");

    }

    private obterAmigos() {
        this.amigoService.obter().subscribe(sub => {
            this.amigos = sub;

            if (this.amigos.length < 1)
                this.alertService.aviso("Nenhum amigo foi encontrado!");
        })
    }

    private obterJogos() {
        this.jogoService.obter().subscribe(sub => {
            this.jogos = sub.filter(x => x.situacao === 'Disponivel');

            if (this.jogos.length < 1)
                this.alertService.aviso("Nenhum jogo foi encontrado!");
        })
    }

}
