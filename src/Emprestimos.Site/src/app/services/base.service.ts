import { environment } from "../../environments/environment";

export abstract class BaseService{
    protected baseUrl: string = environment.apiUrl;
}