import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ExcluirComponent } from 'src/app/componetes/excluir/excluir.component';
import { Funcionario } from 'src/app/models/Funcionario';
import { FuncionarioService } from 'src/app/services/funcionario.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  funcionarios: Funcionario[]= [];
  funcionariosGeral: Funcionario[] = [];

colunas = ['Situacao','Nome', 'Sobrenome', 'Departamento', 'Ações', 'Excluir']

  constructor(private funcionarioService : FuncionarioService, public matDialog: MatDialog){}

  ngOnInit() : void{
      this.funcionarioService.GetFuncionarios().subscribe(data =>{
       const dados = data.dados;

       dados.map((item) =>{
        item.dtDeCriacao = new Date(item.dtDeCriacao!).toLocaleDateString('pt-BR');
        item.dtDeAlteracao = new Date(item.dtDeAlteracao!).toLocaleDateString('pt-BR');
       })
       this.funcionarios = data.dados;
       this.funcionariosGeral = data.dados;
      });
  }

  search(event: Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase();

    this.funcionarios = this.funcionariosGeral.filter(funcionario =>{
      return funcionario.nome.toLowerCase().includes(value);
    })
  }
  openDialog(id : number){
    this.matDialog.open(ExcluirComponent,{
      width: '350px',
      height: '350px',
      data: {
        id: id
      }
    })
  }
}
