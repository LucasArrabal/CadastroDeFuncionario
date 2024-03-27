import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Funcionario } from '../models/Funcionario';
import { Response } from '../models/Response';

@Injectable({
  providedIn: 'root'
})
export class FuncionarioService {
  private api = `${environment.ApiUrl}/Func`

  constructor(private http: HttpClient) { }
  GetFuncionarios() : Observable<Response<Funcionario[]>>{
    return this.http.get<Response<Funcionario[]>>(this.api);
  }
  GetFuncionarioById(id: number): Observable<Response<Funcionario>>{
    return this.http.get<Response<Funcionario>>(`${this.api}/${id}`);
  }
  
  CreateFuncionarios(funcionario: Funcionario) : Observable<Response<Funcionario[]>>{
    return this.http.post<Response<Funcionario[]>>(`${this.api}` , funcionario);
  }
  EditarFuncionario(funcionario : Funcionario) : Observable<Response<Funcionario[]>>{
    return this.http.put<Response<Funcionario[]>>(`${this.api}/UpdateFunc`, funcionario );
  }
  InativaFuncionario(id: number) : Observable<Response<Funcionario[]>>{
    return this.http.put<Response<Funcionario[]>>(`${this.api}/InativFunc?id=${id}`, id );
  }
  AtivaFuncionario(id: number) : Observable<Response<Funcionario[]>>{
    return this.http.put<Response<Funcionario[]>>(`${this.api}/AtivaFunc?id=${id}`, id );
  }
  ExcluirFuncionario(id: number) : Observable<Response<Funcionario[]>>{
    return this.http.delete<Response<Funcionario[]>>(`${this.api}?id=${id}`)
  }
}