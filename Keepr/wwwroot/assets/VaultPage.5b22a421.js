import{H as v,G as V,g as l,h as f,o as r,c,d as t,t as i,l as h,F as g,x as y,i as k}from"./vendor.91a0a055.js";import{_ as x,v as u,k as w,l as m,P as n,r as p,A as d}from"./index.91cc659a.js";const b={setup(){const s=v();return V(async()=>{try{await u.getVault(s.params.id),await w.getVaultKeeps(s.params.id)}catch(e){m.error(e),n.toast(e.message,"error"),p.push({name:"Home"})}}),{activeVault:l(()=>d.activeVault),keeps:l(()=>d.activeVaultKeeps),account:l(()=>d.account),async deleteVault(){try{await n.confirm("Are you sure you want to delete this Vault, "+this.activeVault.name+"?")&&(await u.deleteVault(s.params.id),p.push({name:"Profile",params:{id:this.activeVault.creatorId}}),n.toast("Vault deleted","success"))}catch(e){m.error(e),n.toast(e.message,"error")}}}}},K={class:"container-fluid"},P={class:"row mt-5"},S={class:"col-12 ps-md-5"},j={class:"d-flex justify-content-between flex-column flex-md-row align-items-center"},A={class:"me-md-5 pe-md-5"},B={class:"pt-2 ps-1 fs-4"},C={class:"masonry-frame mt-3 ms-md-4 ps-md-3"};function I(s,e,N,a,D,F){const _=f("Keep");return r(),c("div",K,[t("div",P,[t("div",S,[t("div",j,[t("div",null,[t("h1",null,i(a.activeVault.name),1)]),t("div",A,[a.account.id==a.activeVault.creatorId?(r(),c("button",{key:0,onClick:e[0]||(e[0]=(...o)=>a.deleteVault&&a.deleteVault(...o)),type:"button",class:"btn btn-danger d-flex"}," Delete Vault ")):h("",!0)])]),t("h2",B,"Keeps: "+i(a.keeps.length),1)])]),t("div",C,[(r(!0),c(g,null,y(a.keeps,o=>(r(),c("div",{key:o.id,class:"mb-4"},[k(_,{keep:o},null,8,["keep"])]))),128))])])}var G=x(b,[["render",I],["__scopeId","data-v-2aaeb6a0"]]);export{G as default};
