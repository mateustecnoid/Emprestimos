import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmprestimoModel } from '../../models/emprestimo.model';
import { AlertService } from '../../services/alert.service';
import { EmprestimoService } from '../../services/emprestimo.service';

@Component({
    selector: 'app-emprestimos',
    templateUrl: './emprestimos.component.html',
    styleUrls: ['./emprestimos.component.css']
})
export class EmprestimosComponent implements OnInit {

    emprestimos: EmprestimoModel[];

    constructor(private emprestimoService: EmprestimoService,
        private router: Router,
        private alertService: AlertService) { }


    ngOnInit(): void {
        this.obterEmprestimos();
    }

    obterEmprestimos() {
        this.emprestimoService.obter().subscribe(sub => {
            this.emprestimos = sub;
        })
    }

    novo() {
        this.router.navigate(['novo-emprestimo']);
    }

    editar(Emprestimo: EmprestimoModel) {
        this.router.navigate([`emprestimo/${Emprestimo.id}`]);
    }

    excluir(emprestimo: EmprestimoModel) {
        this.emprestimoService.remover(emprestimo.id).subscribe(sub => {
            this.alertService.sucesso(`Emprestimo "${emprestimo.id}" foi exluido`);
            this.obterEmprestimos();
        });
    }

    devolver(emprestimo: EmprestimoModel) {
        this.emprestimoService.devolver(emprestimo.id).subscribe(sub => {
            this.alertService.sucesso(`Emprestimo "${emprestimo.id}" foi Devolvido`);
            this.obterEmprestimos();
        });
    }

}
