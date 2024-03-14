import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Funcionario } from 'src/app/models/Funcionario';

@Component({
  selector: 'app-funcionario-form',
  templateUrl: './funcionario-form.component.html',
  styleUrls: ['./funcionario-form.component.css']
})
export class FuncionarioFormComponent implements OnInit {
  @Output() onSubmit = new EventEmitter<Funcionario>();
  @Input() btnAcao!: string;
  @Input() btnTitulo!: string;
  @Input() dadosFunc: Funcionario | null =null;
  funcionarioForm!: FormGroup;
  constructor(){}

  ngOnInit(): void {
    this.funcionarioForm = new FormGroup({
      id : new FormControl(this.dadosFunc ? this.dadosFunc.id :0),
      nome : new FormControl(this.dadosFunc ? this.dadosFunc.nome :'', [Validators.required]),
      sobrenome : new FormControl(this.dadosFunc ? this.dadosFunc.sobrenome :'', [Validators.required]),
      derpartamento : new FormControl(this.dadosFunc ? this.dadosFunc.derpartamento :'', [Validators.required]),
      turno : new FormControl(this.dadosFunc ? this.dadosFunc.turno : '', [Validators.required]),
      ativo : new FormControl(this.dadosFunc ? this.dadosFunc.ativo : true),
      dtDeCriacao : new FormControl(new Date()),
      dtDeAlteracao : new FormControl(new Date())
    })
  }

  submit(){
    this.onSubmit.emit(this.funcionarioForm.value);
  }
}
