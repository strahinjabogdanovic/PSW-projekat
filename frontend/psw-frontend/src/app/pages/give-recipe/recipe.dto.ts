export class RecipeDto {
    IdR: number;
    Medicine: string;
    Quantity: string;
    Instructions: string;

    constructor(){
        this.IdR = 0,
        this.Medicine = "",
        this.Quantity = "",
        this.Instructions = ""
    }
}