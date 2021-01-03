import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AmigosComponent } from './views/amigos/amigos.component';
import { AmigosAtualizarComponent } from './views/amigos/atualizar/amigos-atualizar.component';
import { AmigosNovoComponent } from './views/amigos/novo/amigos-novo.component';
import { EmprestimosComponent } from './views/emprestimos/emprestimos.component';
import { EmprestimosNovoComponent } from './views/emprestimos/novo/emprestimos-novo.component';
import { JogosAtualizarComponent } from './views/jogos/atualizar/jogos-atualizar.component';
import { JogosComponent } from './views/jogos/jogos.component';
import { JogosNovoComponent } from './views/jogos/novo/jogos-novo.component';
import { LoginComponent } from './views/login/login.component';
import { NovoUsuarioComponent } from './views/login/novo/novo-usuario.component';


const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'novo-usuario', component: NovoUsuarioComponent },
    { path: 'amigos', component: AmigosComponent },
    { path: 'novo-amigo', component: AmigosNovoComponent },
    { path: 'amigo/:id', component: AmigosAtualizarComponent },
    { path: 'jogos', component: JogosComponent },
    { path: 'novo-jogo', component: JogosNovoComponent },
    { path: 'jogo/:id', component: JogosAtualizarComponent },
    { path: 'emprestimos', component: EmprestimosComponent },
    { path: 'novo-emprestimo', component: EmprestimosNovoComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
