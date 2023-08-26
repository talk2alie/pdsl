import { TestBed } from '@angular/core/testing';

import { PdslApiService } from './pdsl.api.service';

describe('Pdsl.ApiService', () => {
  let service: PdslApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PdslApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
