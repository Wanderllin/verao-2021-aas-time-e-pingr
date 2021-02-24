package br.ime.rest;


import java.util.List;

import javax.annotation.PostConstruct;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;
import br.ime.dao.AccountDAO;
import br.ime.entity.Account;
import br.ime.entity.MessageEvent;
import profileinteractionsrules.ProfileInteractions;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.JsonArray;
import com.google.gson.JsonObject;

@Path("/service")
public class Service {

	private AccountDAO acDAO;
	
	@PostConstruct
	private void init(){
		acDAO = new  AccountDAO();
	}
			
	@GET
	@Path("id/get/{id}")
	@Produces({MediaType.APPLICATION_JSON})
	public Response seachAccount(@PathParam("id") String value) throws Exception{
		Account ac = null;
		Gson jsonConverter = null;
		try{
		 ac = acDAO.searchingAccount(value);
		 System.out.println("FOUND ACCOUNT:\nID ["+ac.getId()+"] USER ["+ac.getUser()+"] PWD ["+ac.getPwd()+"] USER NAME["+ac.getUserName()+"] EMAIL ["+ac.getEmail()+"]");
		 jsonConverter = new GsonBuilder().create();
		} catch (Exception e){
			e.printStackTrace();
		}
		 return Response.status(Status.ACCEPTED).entity(jsonConverter.toJson(ac)).build();
	}
	
	@GET
	@Path("user/get/{user}")
	@Produces({MediaType.APPLICATION_JSON})
	public Response seachAccountUser(@PathParam("user") String value) throws Exception{
		Account ac = null;
		Gson jsonConverter = null;
		try{
		 ac = acDAO.searchingAccount(value);
		 jsonConverter = new GsonBuilder().create();
		} catch (Exception e){
			e.printStackTrace();
		}
		 return Response.status(Status.ACCEPTED).entity(jsonConverter.toJson(ac)).build();
	}
	
	@GET
	@Path("list")
	@Produces({MediaType.APPLICATION_JSON})
	public static Response listAccounts(){
		List<Account> list = null;
		JsonObject jsonObject = null;
		try{
		   AccountDAO acDAO = new  AccountDAO();
		   list = acDAO.listAccount(); 
			Gson gson = new GsonBuilder().create();
	        JsonArray myCustomArray = gson.toJsonTree(list).getAsJsonArray();
	        jsonObject = new JsonObject();
	        jsonObject.add("accountModel", myCustomArray);
		} catch (Exception e){
			e.printStackTrace();
		}
	    return Response.status(Status.ACCEPTED).entity(jsonObject.toString()).build();
	}
	
	@GET
	@Path("/followdestination/get/{user}")
	@Produces({MediaType.APPLICATION_JSON})
	public Response profileInteractions(@PathParam("user") String userToFollow) throws Exception{
		String userOrigin = "DCD";
		String event =  "NewFollower";
		
		MessageEvent me = null;
		Gson jsonConverter = null;
		ProfileInteractions pf = null;
		try{
			me = new MessageEvent();
			pf = new ProfileInteractions();
		    me = pf.searchingAccountToProfileInteractions(userToFollow, userOrigin, event);
		    jsonConverter = new GsonBuilder().create();
		} catch (Exception e){
			e.printStackTrace();
		}
		 return Response.status(Status.ACCEPTED).entity(jsonConverter.toJson(me)).build();
	}

}
