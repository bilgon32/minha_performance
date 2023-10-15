/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { HistoricoFeedbackService } from './historico-feedback.service';

describe('Service: HistoricoFeedback', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HistoricoFeedbackService]
    });
  });

  it('should ...', inject([HistoricoFeedbackService], (service: HistoricoFeedbackService) => {
    expect(service).toBeTruthy();
  }));
});
