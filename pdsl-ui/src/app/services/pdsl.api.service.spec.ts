import { TestBed } from '@angular/core/testing';

import { Pdsl.ApiService } from './pdsl.api.service';

describe('Pdsl.ApiService', () => {
  let service: Pdsl.ApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Pdsl.ApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
