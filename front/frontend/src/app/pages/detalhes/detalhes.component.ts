import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Funcionario } from 'src/app/models/Funcionario';
import { FuncionarioService } from 'src/app/services/funcionario.service';

@Component({
  selector: 'app-detalhes',
  templateUrl: './detalhes.component.html',
  styleUrls: ['./detalhes.component.css']
})
export class DetalhesComponent {
  funcionario?: Funcionario;
  id!: number;
  constructor(private funcionarioService : FuncionarioService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void{

     this.id = Number(this.route.snapshot.paramMap.get("id"));
  
    this.funcionarioService.GetFuncionarioById(this.id).subscribe((data) => {
      const dados = data.dados;
      dados.dtDeAlteracao = new Date(dados.dtDeAlteracao!).toLocaleDateString('pt-BR');
      dados.dtDeCriacao = new Date(dados.dtDeCriacao!).toLocaleDateString('pt-BR');

      this.funcionario = data.dados;
    });
  }

   InativarFuncionario(){
    this.funcionarioService.InativaFuncionario(this.id).subscribe((data) => {
      this.router.navigate(['']);
    });
  }
  
   AtivarFuncionario(){
    this.funcionarioService.AtivaFuncionario(this.id).subscribe((data) => {
      this.router.navigate(['']);
    });
  }
  

   }
