export class RegistrationDTO{
    Id: number;
    Name: string;
    Surname: string;
    Username: string;
    Password: string;
    Phone: string;
    Jmbg: string;
    Role: number;
    Address: string;
    Gender: string;
    Blocked: boolean;

    constructor(){
        this.Id = 0,
        this.Name = "",
        this.Surname = "",
        this.Username = "",
        this.Password = "",
        this.Phone = "",
        this.Jmbg = "",
        this.Role = 0,
        this.Address = "",
        this.Gender = "",
        this.Blocked = false;
    }
}