import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './template/footer/footer.component';
import { NavComponent } from './template/nav/nav.component';
import { HeaderComponent } from './template/header/header.component';
import { AmigosComponent } from './views/amigos/amigos.component';
import { EmprestimosComponent } from './views/emprestimos/emprestimos.component';
import { JogosComponent } from './views/jogos/jogos.component';
import { LoginComponent } from './views/login/login.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AmigoService } from './services/amigo.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AutenticacaoService } from './services/autenticacao.service';
import { JogoService } from './services/jogo.service';
import { UsuarioService } from './services/usuario.service';
import { EmprestimoService } from './services/emprestimo.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { AlertService } from './services/alert.service';
import { AutenticacaoInterceptor } from './interceptors/autenticacao.interceptor';
import { ErroInterceptor } from './interceptors/erro.interceptor';
import { AmigosNovoComponent } from './views/amigos/novo/amigos-novo.component';
import { AmigosAtualizarComponent } from './views/amigos/atualizar/amigos-atualizar.component';
import { JogosNovoComponent } from './views/jogos/novo/jogos-novo.component';
import { JogosAtualizarComponent } from './views/jogos/atualizar/jogos-atualizar.component';
import { EmprestimosNovoComponent } from './views/emprestimos/novo/emprestimos-novo.component';
import { NovoUsuarioComponent } from './views/login/novo/novo-usuario.component';

@NgModule({
    declarations: [
        AppComponent,
        FooterComponent,
        NavComponent,
        HeaderComponent,
        AmigosComponent,
        EmprestimosComponent,
        JogosComponent,
        LoginComponent,
        AmigosNovoComponent,
        AmigosAtualizarComponent,
        JogosNovoComponent,
        JogosAtualizarComponent,
        EmprestimosNovoComponent,
        NovoUsuarioComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        ToastrModule.forRoot(),
    ],
    providers: [
        AmigoService,
        AutenticacaoService,
        JogoService,
        UsuarioService,
        EmprestimoService,
        AlertService,
        { provide: HTTP_INTERCEPTORS, useClass: AutenticacaoInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErroInterceptor, multi: true },
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
