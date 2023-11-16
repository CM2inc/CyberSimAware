using Microsoft.EntityFrameworkCore;

namespace CyberSimAware.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Sim> Sims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Ransomware" },
                new Category { CategoryID = 2, Name = "Phishing" },
                new Category { CategoryID = 3, Name = "Social Engineering" }
            );

            modelBuilder.Entity<Sim>().HasData(
                //Ransomware Category Lifecycle Sims
                new Sim
                {
                    SimID = 1, 
                    CategoryID = 1,
                    Code = "1",
                    Name = "Intro to Ransomware",
                    Abstract = "What is Ransomware, and how is it used maliciously?",
                    Info = " - Ransomware is a type of malicious malware that is leveraged for attack where the malware encrypts an organization’s sensitive data, and the attackers then demand some sort of payment to restore access. When the data is encrypted, this locks the organization out of its own system, essentially rendering their data inaccessible. At its core, ransomware is stealing data with the option of leaking or destroying the stolen data unless a condition, usually payment, is met by the victim. These types of attacks also usually halt an organization’s operations and infrastructure as it creates the dilemma of paying the ransom or attempting to restore the data themselves. While ransomware itself is usually delivered by common methods such as social engineering and phishing, the end goal of a ransomware attack is to force an organization to pay a ransom or meet certain conditions. - Understanding ransomware is crucial for everyday users due to the pervasive and disruptive nature of ransomware attacks. With the ever-evolving nature of the digital world, and people’s personal and professional lives being stored and tied into the digital world, it is only going to become more and more necessary to be aware of the dangers of ransomware. As previously stated, ransomware is usually delivered by common attack actors such as phishing or social engineering and therefore makes user awareness all the more valuable. By understanding ransomware, and the risks associated with it, users can become empowered in recognizing suspicious emails, links, attachments, and more. - Ransomware is a direct risk to any information you may store digitally, personally or professionally, and understanding what it is, how to detect it, and how to combat it, will make sure your organization and its users are ultimately in a safer, cybersecure environment."
                },
                new Sim
                {
                    SimID = 2,
                    CategoryID = 1,
                    Code = "2",
                    Name = "Ransomware Preparation",
                    Abstract = "How to Plan for Ransomware",
                    Info = "1 ~ Make sure your software is up to date. - Software providers issue periodic updates that not only keep your programs running well but also include important security patches and upgrades. It’s important to update your security programs—and any other apps and software you use—regularly and promptly. - Many programs will automatically alert you when an update is needed; however, it’s still worthwhile to check on a regular schedule if there are updates available that you may have missed. 2 ~ Layer your Security Measures (a.k.a. “Defense in Depth”) - What does it mean to have a layered approach to security? - Defense in depth involves implementing multiple layers of security measures and controls to protect an organization's information systems and data. The idea is that if one layer of security fails or is breached, there are additional layers in place to provide protection. - This could be a combination of a firewall, antivirus software, anti-malware software, spam filters, and cloud data loss prevention. 3 ~ Conduct Awareness Training. - This relates to insider threat. - Insider Threat is used to describe any action from an employee that compromises the security of an organization’s data and systems. - Train employees on what ransomware is, safe browsing practices, data handling, reporting suspicious activity, Multi-Factor Authentication, strong passwords to go along with MFA, social engineering workshops, regular refreshers every so often. 4 ~ Configure Access Controls. - This relates to Identity and Access Management. - Use the Principle of Least Privilege (PoLP) to actively manage who can access your information. - Essentially, you only give minimal access to files, programs and accounts to those who need it. 5 ~ Back Up Everything! - If your system does get compromised, you can avoid having to pay a ransom by backing everything up regularly—as regularly as every day, if possible. - Store a copy of your system on an external hard drive that’s kept offline and can’t be accessed by anyone but your trusted team. - Maintain a regular backup schedule. 6 ~ Set up strong spam filters to your email and other messaging services. - The United States Small Business Administration (SBA) recommends Enabling strong spam filters to prevent phishing emails (an attempt to obtain sensitive information electronically) from reaching employees and authenticate inbound email using technologies like Sender Policy Framework (SPF), Domain Message Authentication Reporting and Conformance (DMARC), and DomainKeys Identified Mail (DKIM) to prevent email spoofing. 7 ~ Sign up for regular threat reports. - The Anti-Phishing Working Group website provides regular information about phishing attacks. You can also subscribe to CISA product notifications where regular emails will alert you to new activities, threats, and tips produced by the government in response to the threat landscape. 8 ~ Setup Application Whitelisting. - Application Whitelisting is a security measure that allows trusted files, applications, and processes to be run."
                },
                new Sim
                {
                    SimID = 3,
                    CategoryID = 1,
                    Code = "3",
                    Name = "Ransomware Analysis & Detection",
                    Abstract = "Analyzing a security ecosystem at the holistic level to find malicious users",
                    Info = " ~ What is Threat Detection? - Threat Detection is the process of analyzing a security ecosystem at the holistic level to find malicious users, abnormal activity and anything that could compromise a network. Threat detection is built on threat intelligence, which involves tools that are strategic, tactical and operational (CrowdStrike, 2023). - Analysis and Detection services ensure an agency's or division's information security program is fully implemented and maintained (CISA, 2023). ~ Threat Modeling Methods & MITRE Attack Frameworks. - Plan a Cyber Security Strategy: Use ATT&CK to plan your cyber security strategy. Build your defenses to counter the techniques known to be used against your type of organization and equip yourself with security monitoring to detect evidence of ATT&CK techniques in your network. - Run Adversary Emulation Plans: Use ATT&CK for Adversary Emulation Plans to improve Red team performance. Red teams can develop and deploy a consistent and highly organized approach to defining the tactics and techniques of specific threats, then logically assess their environment to see if the defenses work as expected. - Identify Gaps in Defenses: ATT&CK matrices can help Blue teams better understand the components of a potential or ongoing cyber-attack to identify gaps in defenses and implement solutions for those gaps. ATT&CK documents suggested remediations and compensating controls for the techniques to which you are more prone. - Integrate Threat Intelligence: ATT&CK can effectively integrate your threat intelligence into cyber defense operations. Threats can be mapped to specific attacker techniques to understand if gaps exist, determine risk, and develop an implementation plan to address them. ~ Essential Components of (TDR). - Full Attack Vector Visibility: Effective threat detection requires full visibility into all attack vectors, including the network, email, cloud-based applications, mobile apps, and more. Detecting malware is becoming increasingly difficult as malware becomes more sophisticated and evasive. - High Detection Accuracy: Security Operations Center (SOCs) commonly receive many more alerts than they can process, which results in time being wasted investigating false positives while true threats are overlooked. After a potential threat has been identified, security analysts need tools that support incident investigation and remediation. - MITRE Attack Analysis: The MITRE Attack framework provides a wealth of information about the methods by which an attacker can carry out various stages in a cyberattack. Threat detection and response Solutions should provide mappings to MITRE ATT&CK techniques so that security teams can leverage the associated detection and mitigation recommendations provided by the framework. ~ Effective Threat Detection & Response. - Reduce Attack Dwell Time: the longer that an attacker has access to an organization’s systems, the more damage that they can cause. Rapid threat detection reduces dwell time and the complexity of incident remediation. - Decrease cost of Incident Response: An attacker with extended access to an organization’s systems is much more difficult to dislodge and can cause more damage. The sooner that a threat is detected, the lower the cost of remediation. - Optimizing SOC operations: Many SOCs are overwhelmed by low-quality data, resulting in alert fatigue and missed threat detections. An effective TDR solution enables a SOC to focus its efforts on true threats rather than wasting time on false positives."
                },
                new Sim
                {
                   SimID = 4,
                   CategoryID = 1,
                   Code = "4",
                   Name = "Ransomware Post-Incident Recovery",
                   Abstract = "Methods for recovering from a ransomware attack",
                   Info = "The fastest and easiest method of recovering from a ransomware attack is to restore from known good backups. The fastest and easiest method of recovering from a ransomware attack is to restore from known good backups. However, the root cause of the attack needs to be addressed along with simply replacing the damaged file. 1) All systems being deployed need to be fully patched before redeployment. Take care not to re-infect clean systems during recovery. For example, if a new Virtual Local Area Network (VLAN) has been created for recovery purposes, ensure only clean systems are added. 2) Systems should be hardened to an industry standard to minimize initial attack surfaces and limit the chances of weak or default configurations making it to production. 3) Before deployment, the systems must be scanned for vulnerabilities. 4) Ensure that your backup process has been improved to include ransomware resistance. 5) Ensure that gaps where there was failure of endpoint protection have been closed or mitigated before redeploying systems. 6) Document lessons learned from the incident and associated response activities to inform updates to—and refine—organizational policies, plans, and procedures and guide future exercises of the same. 7) Let any affected person(s) know what happened and what, if anything, they need to do. The wording should be such to have a minimal chance of causing panic in anyone. 8) Consider sharing lessons learned and relevant indicators of compromise with CISA or your sector ISAC to benefit others within the community."
               },
               new Sim
               {
                   SimID = 5,
                   CategoryID = 1,
                   Code = "5",
                   Name = "Ransomware Scenario 1",
                   Abstract = "Example Ransomware Scenario",
                   Info = "~ Incident: At 10:00 AM on a regular workday, multiple employees at Swift Solutions report unusual pop-up messages appearing on their computers, indicating that their files have been encrypted. Simultaneously, the company's internal communication platform experiences disruptions. ~ Initial Investigation: The IT team quickly identifies this as a ransomware attack and determines that the malware has entered the network through a phishing email that an employee unwittingly opened and clicked on a link. ~ Ransom Demand: Shortly after the attack, the company receives an anonymous message demanding a significant sum of 350 Bitcoin ($12,349,050.00) in exchange for the decryption keys. The attackers threaten to leak sensitive company data if the ransom is not paid within a specified timeframe."
               },
               new Sim
               {
                   SimID = 6,
                   CategoryID = 1,
                   Code = "6",
                   Name = "Ransomware Scenario 2",
                   Abstract = "Example Ransomware Scenario",
                   Info = "~ Incident: Following a recent layoff, a terminated employee (let's call them 'Alex') from a mid-sized financial services firm, 'Horizon Finance,' who had extensive knowledge of the company's systems and data, launches a ransomware attack on the organization's network. ~ Attack Execution: Using previously obtained login credentials and unauthorized access, Alex remotely infiltrates the company's network infrastructure. Using malware that was planted before departure, they trigger a ransomware attack during the weekend, aiming to encrypt sensitive data and disrupt the company's operations. ~ Ransom Demand: The ransom note doesn’t directly identify the perpetrator but indicates that sensitive financial and client data will be exposed unless a significant ransom is paid in cryptocurrency within a specific timeframe. ~ Impacted Systems: The attack successfully encrypts critical financial databases, client records, and internal communication systems. This causes a halt in daily operations, hindering access to crucial data required for ongoing financial transactions."
               },
               new Sim
               {
                   SimID = 7,
                   CategoryID = 1,
                   Code = "7",
                   Name = "Ransomware Scenario 3",
                   Abstract = "Example Ransomware Scenario",
                   Info = "~ Incident: A large retail corporation, 'TechMart,' experiences a ransomware attack due to an unpatched and vulnerable point-of-sale (POS) system. The attack occurs during a busy holiday shopping weekend. ~ Attack Execution: Cybercriminals exploit a known vulnerability in the POS system software that wasn’t updated with the latest security patches. Through this vulnerability, they inject ransomware into the system, causing a widespread encryption of customer transaction data, inventory records, and payment processing systems. ~ Ransom Demand: The attackers demand a substantial ransom in cryptocurrency within a short time frame in exchange for the decryption keys. They threaten to expose the compromised customer data if the demands are not met. ~ Impacted Systems: The attack disrupts the point-of-sale terminals, halting transactions during a critical shopping period. This affects the entire supply chain, from inventory management to customer payment processing, potentially causing financial loss and reputational damage."
               },

                //Phishing Category 
                new Sim
                {
                    SimID = 201,
                    CategoryID = 2,
                    Code = "201",
                    Name = "Phishing 1",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 202,
                    CategoryID = 2,
                    Code = "202",
                    Name = "Phishing 2",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 203,
                    CategoryID = 2,
                    Code = "203",
                    Name = "Phishing 3",
                    Abstract = "",
                    Info = ""
                },
                //Social Engineering
                new Sim
                {
                    SimID = 301,
                    CategoryID = 3,
                    Code = "301",
                    Name = "Social Engineering 1",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 302,
                    CategoryID = 3,
                    Code = "302",
                    Name = "Social Engineering 2",
                    Abstract = "",
                    Info = ""
                },
                new Sim
                {
                    SimID = 303,
                    CategoryID = 3,
                    Code = "303",
                    Name = "Social Engineering 3",
                    Abstract = "",
                    Info = ""
                }
            );
        }
    }
}