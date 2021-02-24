package br.ime.entity;

public class MessageEvent {

	private String event;
	private String originUserId;
	private String destinationUserId;
	
	public String getEvent() {
		return event;
	}
	public void setEvent(String event) {
		this.event = event;
	}
	public String getOriginUserId() {
		return originUserId;
	}
	public void setOriginUserId(String originUserId) {
		this.originUserId = originUserId;
	}
	public String getDestinationUserId() {
		return destinationUserId;
	}
	public void setDestinationUserId(String destinationUserId) {
		this.destinationUserId = destinationUserId;
	}
	
	
}
