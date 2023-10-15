import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { HistoricoFeedback } from '../models/historico-feedback.model';

@Injectable({
  providedIn: 'root'
})
export class HistoricoFeedbackService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public sendFeedback(feedback: HistoricoFeedback) {
    return this.http.post(this.baseUrl + 'api/HistoricoFeedback', feedback);
  }

  public getReceived() {
    return this.http.get<HistoricoFeedback[]>(this.baseUrl + 'api/HistoricoFeedback/recebidos');
  }

  public getSent() {
    return this.http.get<HistoricoFeedback[]>(this.baseUrl + 'api/HistoricoFeedback/enviados');
  }

  public getById(id: string) {
    return this.http.get<HistoricoFeedback>(this.baseUrl + `api/HistoricoFeedback/${id}`);
  }
}
