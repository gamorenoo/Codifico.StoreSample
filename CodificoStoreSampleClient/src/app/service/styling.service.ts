import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StylingService {

  constructor() { }

  setTitleColorStyle(el: HTMLElement, backgroundColor: string) {
    if (el) {
      el.style.backgroundColor = backgroundColor;
      el.querySelectorAll('.card-header').forEach(iEl => {
        (iEl as HTMLElement).style.backgroundColor = backgroundColor;
      });
      document.querySelectorAll('div.dx-popup-title').forEach(iEl => {
        (iEl as HTMLElement).style.backgroundColor = backgroundColor;
      });
    }
  }

  setTitleTextColorStyle(el: HTMLElement, titleTextColor: string) {
    if (el) {
      el.style.color = titleTextColor;
      document.querySelectorAll('div.dx-popup-title').forEach(iEl => {
        (iEl as HTMLElement).style.color = titleTextColor;
      });
      document.querySelectorAll('div.dx-popup-title i').forEach(iEl => {
        (iEl as HTMLElement).style.color = titleTextColor;
      });
      el.querySelectorAll('.card-header button').forEach(iEl => {
        (iEl as HTMLElement).classList.remove('btn-link');
        (iEl as HTMLElement).style.color = titleTextColor;
      });
    }
  }
  
}