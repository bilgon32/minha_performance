import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Feedback } from '../models/feedback.model';
import { HistoricoFeedback } from '../models/historico-feedback.model';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  public getFeedbackList() {
    return this.http.get<Feedback[]>(this.baseUrl + 'api/Feedback');
  }
}
