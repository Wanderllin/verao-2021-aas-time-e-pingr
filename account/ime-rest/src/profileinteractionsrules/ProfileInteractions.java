package profileinteractionsrules;

import br.ime.dao.AccountDAO;
import br.ime.entity.Account;
import br.ime.entity.MessageEvent;

public class ProfileInteractions {

	
	/**
	 * @author Denilson
	 * @param userOrigin
	 * @param userFollowDestination
	 * @param event
	 * @return
	 * @throws Exception
	 * Vincula status de "NewFollow" entre "userOrigin" e "userToFollow" 
	 */
	public MessageEvent searchingAccountToProfileInteractions(String userToFollow, String userOrigin, String event) throws Exception{
		MessageEvent me = null;
		Account acOrigin = null;
		Account acOFollowDestination = null;
		AccountDAO ad = null;
		try{
			me = new MessageEvent();
			acOrigin = new Account();
			acOFollowDestination = new Account();
			ad = new AccountDAO();
		    acOrigin=ad.searchingAccount(userOrigin);
		    acOFollowDestination=ad.searchingAccount(userToFollow);
		
		    me.setEvent(event);
		    me.setOriginUserId(acOrigin.getId());
		    me.setDestinationUserId(acOFollowDestination.getId());
		} catch (Exception e){
			e.printStackTrace();
		}
		return me;
	}
	
	
	
}
