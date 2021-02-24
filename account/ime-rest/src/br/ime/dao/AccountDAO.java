package br.ime.dao;

import java.util.ArrayList;
import java.util.List;

import br.ime.entity.Account;

public class AccountDAO {

	/**
	 * @author Denilson
	 * @return
	 * @throws Exception
	 */
	public List<Account> listAccount() throws Exception{
		List<Account> list = new ArrayList();
		Account ac1 = new Account();
		ac1.setId("1");
		ac1.setUser("DCD");
		ac1.setPwd("DCD");
		ac1.setUserName("Denilson");
		ac1.setEmail("denilson@email.com");
		list.add(ac1);
		Account ac2 = new Account();
		ac2.setId("2");
		ac2.setUser("VDLN");
		ac2.setPwd("VDLN");
		ac2.setUserName("Vanderlin");
		ac2.setEmail("vanderlin@email.com");
		list.add(ac2);
		Account ac3 = new Account();
		ac3.setId("3");
		ac3.setUser("RF");
		ac3.setPwd("RF");
		ac3.setUserName("Renan Ferreira");
		ac3.setEmail("renanferreira@email.com");
		list.add(ac3);
		Account ac4 = new Account();
		ac4.setId("4");
		ac4.setUser("VC");
		ac4.setPwd("VC");
		ac4.setUserName("VICTOR");
		ac4.setEmail("victor@email.com");
		list.add(ac4);
		Account ac5 = new Account();
		ac5.setId("5");
		ac5.setUser("GUILH");
		ac5.setPwd("GUILH");
		ac5.setUserName("GUILHERME");
		ac5.setEmail("guilherme@email.com");
		list.add(ac5);
		Account ac6 = new Account();
		ac6.setId("6");
		ac6.setUser("MR");
		ac6.setPwd("MR");
		ac6.setUserName("Marcos");
		ac6.setEmail("marcos@email.com");
		list.add(ac6);
		
		return list;
	}
	
	/**
	 * @author Denilson
	 * @param id
	 * @return
	 * @throws Exception
	 */
	public Account searchingAccount(String value)throws Exception{
		Account ac = new Account();
		List<Account> list = listAccount();
		for(int i = 0; i < list.size();i++){
			if(list.get(i).getId().contains(value) || list.get(i).getUser().contains(value)){
				ac.setId(list.get(i).getId());
				ac.setUser(list.get(i).getUser());
				ac.setPwd(list.get(i).getPwd());
				ac.setUserName(list.get(i).getUserName());
				ac.setEmail(list.get(i).getEmail());
				break;
			}
		}
	    return ac;
	}
	
	
	
	
}
