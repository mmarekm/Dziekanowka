const klucz = {'20260726':'Ndz17zwA', '20260727':'pn17zwII', '20260728':'wt17zwII', '20260729':['sr17zwII', 'MartyMariiILazarza'], '20260730':'cz17zwII', '20260731':['pt17zwII', 'IgnacegoZLoyoli'], '20260801':['sb17zwII', 'AlfonsaMariiLiguoriegoBiskupaDoktoraKosciola'], '20260802':'Ndz18zwA', '20260803':'pn18zwIIA', '20260804':['wt18zwIIA', 'JanaMariiVianneya'], '20260805':'sr18zwII', '20260806':'PrzemienieniePanskieA', '20260807':'pt18zwII', '20260808':['sb18zwII', 'Dominika'], '20260809':'Ndz19zwA', '20260810':'Wawrzynca', '20260811':['wt19zwII', 'Klary'], '20260812':'sr19zwII', '20260813':'cz19zwII', '20260814':['pt19zwII', 'MaksymilianaMariiKolbego', 'WigiliaWniebowzieciaNMP'], '20260815':'WniebowziecieNMP', '20260816':'Ndz20zwA', '20260817':['pn20zwII', 'Jacka'], '20260818':'wt20zwII', '20260819':'sr20zwII', '20260820':['cz20zwII', 'BernardaOpataDoktoraKosciola'], '20260821':['pt20zwII', 'PiusaX'], '20260822':['sb20zwII', 'NMPKrolowej'], '20260823':'Ndz21zwA', '20260824':'BartlomiejaApostola', '20260825':'wt21zwII', '20260826':'NMPCzestochowskiej', '20260827':['cz21zwII', 'Moniki'], '20260828':['pt21zwII', 'AugustynaBiskupaDoktoraKosciola'], '20260829':['sb21zwII', 'MeczenstwoJanaChrzciciela'], '20260830':'Ndz22zwA', '20260831':'pn22zwII', '20260901':'wt22zwII', '20260902':'sr22zwII', '20260903':['cz22zwII', 'GrzegorzaWielkiegoPapiezaDoktoraKosciola'], '20260904':'pt22zwII', '20260905':'sb22zwII', '20260906':'Ndz23zwA', '20260907':'pn23zwII', '20260908':'NarodzenieNMP', '20260909':'sr23zwII', '20260910':'cz23zwII', '20260911':'pt23zwII', '20260912':'sb23zwII', '20260913':'Ndz24zwA', '20260914':'PodwyzszenieKrzyzaSwietego', '20260915':['wt24zwII', 'NMPBolesnej'], '20260916':['sr24zwII', 'KorneliuszaPapiezaCyprianaBiskupaMeczennikow'], '20260917':'cz24zwII', '20260918':'StanislawaKostki', '20260919':'sb24zwII', '20260920':'Ndz25zwA', '20260921':'MateuszaApostolaIEwangelisty', '20260922':'wt25zwII', '20260923':['sr25zwII', 'PioZPietrelciny'], '20260924':'cz25zwII', '20260925':'pt25zwII', '20260926':'sb25zwII', '20260927':'Ndz26zwA', '20260928':['pn26zwII', 'WaclawaMeczennika'], '20260929':'ArchaniolowMichalaGabrielaIRafala', '20260930':['sr26zwII', 'HieronimaDoktoraKosciola'], '20261001':['cz26zwII', 'TeresyOdDzieciatkaJezusDoktoraKosciola'], '20261002':['pt26zwII', 'AniolowStrozow'], '20261003':'sb26zwII', '20261004':'Ndz27zwA', '20261005':['pn27zwII', 'FaustynyKowalskiej'], '20261006':'wt27zwII', '20261007':['sr27zwII', 'NMPRozancowej'], '20261008':'cz27zwII', '20261009':'pt27zwII', '20261010':'sb27zwII', '20261011':'Ndz28zwA', '20261012':'pn28zwII', '20261013':['wt28zwII', 'HonorataKozminskiego'], '20261014':'sr28zwII', '20261015':['cz28zwII', 'TeresyOdJezusaDoktoraKosciola'], '20261016':['pt28zwII', 'JadwigiSlaskiej'], '20261017':['sb28zwII', 'IgnacegoAntiochenskiego'], '20261018':'Ndz29zwA', '20261019':['pn29zwII', 'JerzegoPopieluszki'], '20261020':['wt29zwII', 'JanaKantego'], '20261021':'sr29zwII'};

function dataDoStr(data) {
    const rok = data.getFullYear();
    const miesiac = String(data.getMonth() + 1).padStart(2, '0');
    const dzien = String(data.getDate()).padStart(2, '0');
    return `${rok}${miesiac}${dzien}`;
}

const cacheJson = {};

function pobierzJson(ksiega) {
    if (cacheJson[ksiega]) {
        return Promise.resolve(cacheJson[ksiega]);
    }
    return fetch(`Biblia/${ksiega}.json`)
        .then(r => r.json())
        .then(dane => {
            cacheJson[ksiega] = dane;
            return dane;
        });
}

function wypelnijWersety() {
    const elementy = document.querySelectorAll('.werset');
    elementy.forEach(p => {
        const ref = p.getAttribute('data-ref');
        if (!ref) return;
        const czesci = ref.trim().split(' ');
        const ksiega = czesci[0];
        const zakresy = czesci[1].split('.');
        const rozdzial = zakresy[0].split(',')[0];
        pobierzJson(ksiega).then(dane => {
            const tekstoweKlucze = p.classList.contains('psalm');
            if (tekstoweKlucze) {
                const linie = [];
                zakresy.forEach(zakres => {
                    const klucz = zakres.includes(',')
                        ? zakres.split(',')[1]
                        : zakres;
                    if (dane[rozdzial] && dane[rozdzial][klucz]) {
                        linie.push(dane[rozdzial][klucz]);
                    }
                });
                p.innerHTML = linie.join('<br>');
            } else {
                let tekst = '';
                zakresy.forEach(zakres => {
                    let wersety_str = zakres.includes(',')
                        ? zakres.split(',')[1]
                        : zakres;
                    if (/^\d+[a-z]$/.test(wersety_str)) {
                        if (dane[rozdzial] && dane[rozdzial][wersety_str]) {
                            tekst += dane[rozdzial][wersety_str] + ' ';
                        }
                    } else if (wersety_str.includes('-')) {
                        const czesciZakresu = wersety_str.split('-');
                        const odStr = czesciZakresu[0];
                        const doStr = czesciZakresu[1];
                        const od = parseInt(odStr);
                        const doNum = parseInt(doStr);
                        if (/[a-z]$/.test(odStr)) {
                            if (dane[rozdzial] && dane[rozdzial][odStr]) {
                                tekst += dane[rozdzial][odStr] + ' ';
                            }
                        }
                        const odNum = /[a-z]$/.test(odStr) ? od + 1 : od;
                        for (let i = odNum; i <= doNum; i++) {
                            if (dane[rozdzial] && dane[rozdzial][String(i)]) {
                                tekst += dane[rozdzial][String(i)] + ' ';
                            }
                        }
                        if (/[a-z]$/.test(doStr)) {
                            if (dane[rozdzial] && dane[rozdzial][doStr]) {
                                tekst += dane[rozdzial][doStr] + ' ';
                            }
                        }
                    } else {
                        const i = Number(wersety_str);
                        if (dane[rozdzial] && dane[rozdzial][String(i)]) {
                            tekst += dane[rozdzial][String(i)] + ' ';
                        }
                    }
                });
                p.textContent = tekst.trim();
            }
        }).catch(() => {
            p.textContent = `Brak tekstu: ${ref}`;
        });
    });
}

function pobierzFragment(nazwaPliku, idElementu) {
    const element = document.getElementById(idElementu);
    if (!element) return;

    const pliki = Array.isArray(nazwaPliku) ? nazwaPliku : (nazwaPliku ? [nazwaPliku] : []);

    if (pliki.length === 0) {
        element.innerHTML = '';
        return;
    }

    element.innerHTML = '';

    pliki.forEach(plik => {
        fetch(`Slowo/${plik}.html`)
            .then(r => r.text())
            .then(html => {
                const parser = new DOMParser();
                const doc = parser.parseFromString(html, 'text/html');
                const div = document.createElement('div');
                div.innerHTML = doc.getElementById('fragment').innerHTML;
                element.appendChild(div);
                wypelnijWersety();
            })
            .catch(() => {});
    });
}

const dzis = new Date();
const jutro = new Date(dzis);
jutro.setDate(dzis.getDate() + 1);

const kluczDzis = klucz[dataDoStr(dzis)];
const kluczJutro = klucz[dataDoStr(jutro)];

pobierzFragment(kluczDzis, 'trescDzis');
pobierzFragment(kluczJutro, 'trescJutro');