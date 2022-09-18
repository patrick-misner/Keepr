import{g as p,A as i,_ as w,u as x,d as K,l as P,P as b,b as d,M as y,r as h,o as s,c as o,a,t as n,h as m,F as u,e as f,i as V,f as _}from"./index.f054cde9.js";class F{async getProfile(t){const l=await p.get("api/profiles/"+t);i.profile=l.data}async getProfileVaults(t){const l=await p.get("api/profiles/"+t+"/vaults");i.profileVaults=l.data}async getProfileKeeps(t){const l=await p.get("api/profiles/"+t+"/keeps");i.profileKeeps=l.data}}const g=new F;const C={setup(){const c=x();return K(async()=>{try{await g.getProfile(c.params.id),await g.getProfileVaults(c.params.id),await g.getProfileKeeps(c.params.id)}catch(t){P.error(t),b.toast(t.message,"error")}}),{profile:d(()=>i.profile),profileKeeps:d(()=>i.profileKeeps),profileVaults:d(()=>i.profileVaults),myVaults:d(()=>i.myVaults),account:d(()=>i.account),triggerKeepForm(){y.getOrCreateInstance(document.getElementById("keep-form")).show()},triggerVaultForm(){y.getOrCreateInstance(document.getElementById("vault-form")).show()}}}},B={class:"container-fluid"},I={class:"row"},A={class:"col-12 mt-5 px-md-5"},N={class:"d-flex flex-md-row flex-column"},S=["src","alt"],E={class:"mx-md-5 pt-3"},M={class:"pt-3"},O={key:0},j={key:1},D={class:"row mt-5"},L={class:"col-12 mt-5 ps-md-5"},R=V(" Vaults "),T={key:0,class:"masonry-frame mt-3 ms-md-4"},q={key:1,class:"masonry-frame mt-3 ms-md-4"},z={class:"row mt-5"},G={class:"col-12 mt-5 ps-md-5"},H=V(" Keeps "),J={class:"masonry-frame mt-3 ms-md-4"};function Q(c,t,l,e,U,W){const v=h("Vault"),k=h("Keep");return s(),o("div",B,[a("div",I,[a("div",A,[a("div",N,[a("div",null,[a("img",{class:"profile-img rounded",src:e.profile.picture,alt:e.profile.picture},null,8,S)]),a("div",E,[a("h3",null,n(e.profile.name),1),a("div",M,[e.account.id!=e.profile.id?(s(),o("h4",O," Vaults: "+n(e.profileVaults.length),1)):m("",!0),e.account.id==e.profile.id?(s(),o("h4",j," Vaults: "+n(e.myVaults.length),1)):m("",!0),a("h4",null,"Keeps: "+n(e.profileKeeps.length),1)])])])])]),a("div",D,[a("div",L,[a("h2",null,[R,e.account.id==e.profile.id?(s(),o("i",{key:0,class:"mdi mdi-plus text-primary selectable",title:"Add a Vault",onClick:t[0]||(t[0]=(...r)=>e.triggerVaultForm&&e.triggerVaultForm(...r))})):m("",!0)])])]),e.account.id==e.profile.id?(s(),o("div",T,[(s(!0),o(u,null,f(e.myVaults,r=>(s(),o("div",{key:r.id,class:"mb-3"},[_(v,{vault:r},null,8,["vault"])]))),128))])):(s(),o("div",q,[(s(!0),o(u,null,f(e.profileVaults,r=>(s(),o("div",{key:r.id,class:"mb-3"},[_(v,{vault:r},null,8,["vault"])]))),128))])),a("div",z,[a("div",G,[a("h2",null,[H,e.account.id==e.profile.id?(s(),o("i",{key:0,title:"Add a Keep",class:"mdi mdi-plus text-primary selectable grow",onClick:t[1]||(t[1]=(...r)=>e.triggerKeepForm&&e.triggerKeepForm(...r))})):m("",!0)])])]),a("div",J,[(s(!0),o(u,null,f(e.profileKeeps,r=>(s(),o("div",{key:r.id,class:"mb-3"},[_(k,{keep:r},null,8,["keep"])]))),128))])])}var Y=w(C,[["render",Q],["__scopeId","data-v-1c7aa1ac"]]);export{Y as default};