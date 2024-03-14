export interface Funcionario{
    id? : number;
    nome: string;
    sobrenome: string;
    derpartamento: string;
    ativo: boolean;
    turno: string;
    dtDeCriacao? : string;
    dtDeAlteracao? : string;
}