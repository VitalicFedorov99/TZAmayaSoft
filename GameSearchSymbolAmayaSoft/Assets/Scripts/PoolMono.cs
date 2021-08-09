using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PoolMono <T> where T : MonoBehaviour
{
     public T prefab{get;}
     public bool autoExpand{get;set;}
     public Transform container{get;}

     private List<T> pool;

     public PoolMono(T _prefab, int count)
     {

         prefab=_prefab;
         container=null;
         
         CreatePool(count);
     }
     public PoolMono(T _prefab,int count,Transform _container)
     {
       prefab=_prefab;
       container=_container;

       CreatePool(count); 

     }


     private void CreatePool(int count)
     {
        pool=new List<T>();
        for(int i=0;i<count;i++)
        {
           CreateObject();
        }

     } 

     private T CreateObject(bool isActiveByDefault=false)
     {
        var createObject =GameObject.Instantiate(prefab,container);
        createObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createObject);
        return createObject;
     } 

     public bool HasFreeElement( out T _element)
     {
        foreach (var mono in pool)
        {
          if(!mono.gameObject.activeInHierarchy)
          {
                 
              _element=mono;
              mono.gameObject.SetActive(true);
              return true;
          }
        }
        _element=null;
        return false;

     }



    public void DeletePool()
    {
        
        for(int i = 0; i < pool.Count; i++)
        {
            pool.Remove(pool[i]);
        }
        pool.Clear();
            
        
    }

   //  public void Deactivate()
   //  {
   //     for(int i = 0; i < pool.Count; i++)
   //     {
   //         pool[i].gameObject.SetActive(false);
   //     }
   //  }   

     public T GetFreeElement()
     {

         if(HasFreeElement(out var element))
         return element;
         if(autoExpand)
         {
             return CreateObject(true);
         }
         throw new Exception($"There is no free elements in pool of type{typeof(T)}");
     }
}
